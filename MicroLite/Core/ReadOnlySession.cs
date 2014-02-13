﻿// -----------------------------------------------------------------------
// <copyright file="ReadOnlySession.cs" company="MicroLite">
// Copyright 2012 - 2014 Project Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
namespace MicroLite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using MicroLite.Builder;
    using MicroLite.Dialect;

    /// <summary>
    /// The default implementation of <see cref="IReadOnlySession" />.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("ConnectionScope: {ConnectionScope}")]
    internal class ReadOnlySession : SessionBase, IReadOnlySession, IIncludeSession, IAdvancedReadOnlySession
    {
        private readonly Queue<Include> includes = new Queue<Include>();
        private readonly Queue<SqlQuery> queries = new Queue<SqlQuery>();
        private readonly ISqlDialect sqlDialect;

        internal ReadOnlySession(
            ConnectionScope connectionScope,
            IDbConnection connection,
            ISqlDialect sqlDialect)
            : base(connectionScope, connection)
        {
            this.sqlDialect = sqlDialect;
        }

        public IAdvancedReadOnlySession Advanced
        {
            get
            {
                return this;
            }
        }

        public IIncludeSession Include
        {
            get
            {
                return this;
            }
        }

        protected ISqlDialect SqlDialect
        {
            get
            {
                return this.sqlDialect;
            }
        }

        public IIncludeMany<T> All<T>() where T : class, new()
        {
            var sqlQuery = new SelectSqlBuilder(this.SqlDialect.SqlCharacters)
                .From(typeof(T))
                .ToSqlQuery();

            var include = this.Include.Many<T>(sqlQuery);

            return include;
        }

        public void ExecutePendingQueries()
        {
            if (Log.IsDebug)
            {
                Log.Debug(Messages.Session_ExecutingQueries, this.queries.Count.ToString(CultureInfo.InvariantCulture));
            }

            try
            {
                if (this.SqlDialect.SupportsBatchedQueries && this.queries.Count > 1)
                {
                    this.ExecuteQueriesCombined();
                }
                else
                {
                    this.ExecuteQueriesIndividually();
                }
            }
            catch (MicroLiteException)
            {
                // Don't re-wrap MicroLite exceptions
                throw;
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                throw new MicroLiteException(e.Message, e);
            }
            finally
            {
                this.includes.Clear();
                this.queries.Clear();
            }
        }

        public IList<T> Fetch<T>(SqlQuery sqlQuery)
        {
            var include = this.Include.Many<T>(sqlQuery);

            this.ExecutePendingQueries();

            return include.Values;
        }

        IInclude<T> IIncludeSession.Single<T>(object identifier)
        {
            this.ThrowIfDisposed();

            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            var sqlQuery = this.SqlDialect.CreateQuery(StatementType.Select, typeof(T), identifier);

            var include = this.Include.Single<T>(sqlQuery);

            return include;
        }

        IInclude<T> IIncludeSession.Single<T>(SqlQuery sqlQuery)
        {
            this.ThrowIfDisposed();

            if (sqlQuery == null)
            {
                throw new ArgumentNullException("sqlQuery");
            }

            var include = new IncludeSingle<T>();

            this.includes.Enqueue(include);
            this.queries.Enqueue(sqlQuery);

            return include;
        }

        T IReadOnlySession.Single<T>(object identifier)
        {
            var include = this.Include.Single<T>(identifier);

            this.ExecutePendingQueries();

            return include.Value;
        }

        T IReadOnlySession.Single<T>(SqlQuery sqlQuery)
        {
            var include = this.Include.Single<T>(sqlQuery);

            this.ExecutePendingQueries();

            return include.Value;
        }

        public IIncludeMany<T> Many<T>(SqlQuery sqlQuery)
        {
            this.ThrowIfDisposed();

            if (sqlQuery == null)
            {
                throw new ArgumentNullException("sqlQuery");
            }

            var include = new IncludeMany<T>();

            this.includes.Enqueue(include);
            this.queries.Enqueue(sqlQuery);

            return include;
        }

        public PagedResult<T> Paged<T>(SqlQuery sqlQuery, PagingOptions pagingOptions)
        {
            this.ThrowIfDisposed();

            if (sqlQuery == null)
            {
                throw new ArgumentNullException("sqlQuery");
            }

            if (pagingOptions == PagingOptions.None)
            {
                throw new MicroLiteException(Messages.Session_PagingOptionsMustNotBeNone);
            }

            var countSqlQuery = this.SqlDialect.CountQuery(sqlQuery);
            var pagedSqlQuery = this.SqlDialect.PageQuery(sqlQuery, pagingOptions);

            var includeCount = this.Include.Scalar<int>(countSqlQuery);
            var includeMany = this.Include.Many<T>(pagedSqlQuery);

            this.ExecutePendingQueries();

            var page = (pagingOptions.Offset / pagingOptions.Count) + 1;

            return new PagedResult<T>(page, includeMany.Values, pagingOptions.Count, includeCount.Value);
        }

        public IInclude<T> Scalar<T>(SqlQuery sqlQuery)
        {
            this.ThrowIfDisposed();

            if (sqlQuery == null)
            {
                throw new ArgumentNullException("sqlQuery");
            }

            var include = new IncludeScalar<T>();

            this.includes.Enqueue(include);
            this.queries.Enqueue(sqlQuery);

            return include;
        }

        private void ExecuteQueriesCombined()
        {
            var combinedSqlQuery = this.SqlDialect.Combine(this.queries);

            using (var command = this.CreateCommand())
            {
                try
                {
                    this.SqlDialect.BuildCommand(command, combinedSqlQuery);

                    using (var reader = command.ExecuteReader())
                    {
                        do
                        {
                            var include = this.includes.Dequeue();
                            include.BuildValue(reader);
                        }
                        while (reader.NextResult());
                    }
                }
                finally
                {
                    this.CommandCompleted();
                }
            }
        }

        private void ExecuteQueriesIndividually()
        {
            do
            {
                using (var command = this.CreateCommand())
                {
                    try
                    {
                        var sqlQuery = this.queries.Dequeue();
                        this.SqlDialect.BuildCommand(command, sqlQuery);

                        using (var reader = command.ExecuteReader())
                        {
                            var include = this.includes.Dequeue();
                            include.BuildValue(reader);
                        }
                    }
                    finally
                    {
                        this.CommandCompleted();
                    }
                }
            }
            while (this.queries.Count > 0);
        }
    }
}