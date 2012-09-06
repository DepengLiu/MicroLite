﻿// -----------------------------------------------------------------------
// <copyright file="IIncludeSession.cs" company="MicroLite">
// Copyright 2012 Trevor Pilley
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
namespace MicroLite
{
    using System;

    /// <summary>
    /// The interface which provides access to include operations.
    /// </summary>
    /// <remarks>
    /// These operations allow for batch included values and have been moved to a separate interface to avoid
    /// cluttering the ISession API.
    /// </remarks>
    public interface IIncludeSession : IHideObjectMethods
    {
        /// <summary>
        /// Includes many instances based upon the specified SQL query.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="sqlQuery">The SQL query to execute.</param>
        /// <returns>A pointer to the included instances of the specified type.</returns>
        /// <example>
        /// <code>
        /// using (var session = sessionFactory.OpenSession())
        /// {
        ///     // Query to fetch the invoices for the customer.
        ///     var invoicesQuery = new SqlQuery("SELECT * FROM Invoices WHERE CustomerId = @p0", 1792);
        ///
        ///     // Tell the session to include the invoices.
        ///     var invoices = session.Include.Many&lt;Invoice&gt;(invoicesQuery);
        ///
        ///     // At this point, invoices will point to an IIncludeMany&lt;Invoice&gt; which will have no values.
        ///     // You can call include for multiple things, they will all be loaded in a single database call once
        ///     // either ISession.Single, ISession.Fetch or ISession.Paged is called.
        ///
        ///     // Load the customer.
        ///     var customer = session.Single&lt;Customer&gt;(1792);
        ///
        ///     // We can now acces the invoices for the customer
        ///     foreach (var invoice in invoices.Values)
        ///     {
        ///         // ...
        ///     }
        /// }
        /// </code>
        /// </example>
        IIncludeMany<T> Many<T>(SqlQuery sqlQuery) where T : class, new();

        /// <summary>
        /// Includes the instance of the specified type which corresponds to the row with the specified identifier
        /// in the mapped table.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="identifier">The record identifier.</param>
        /// <returns>A pointer to the included instance of the specified type.</returns>
        /// <exception cref="ObjectDisposedException">Thrown if the session has been disposed.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the specified instance is null.</exception>
        /// <exception cref="MicroLiteException">Thrown if there is an error executing the query.</exception>
        /// <example>
        /// <code>
        /// using (var session = sessionFactory.OpenSession())
        /// {
        ///     // Tell the session to include the customer.
        ///     var customer = session.Include.Single&lt;Customer&gt;(3264);
        ///
        ///     // At this point, invoices will point to an IInclude&lt;Customer&gt; which will have no value.
        ///     // You can call include for multiple things, they will all be loaded in a single database call once
        ///     // either ISession.Single, ISession.Fetch or ISession.Paged is called.
        ///
        ///     // Query to fetch the invoices for the customer.
        ///     var invoicesQuery = new SqlQuery("SELECT * FROM Invoices WHERE CustomerId = @p0", 3264);
        ///
        ///     // Load the invoices.
        ///     var invoices = session.Fetch&lt;Invoice&gt;(query);
        ///
        ///     // We can now acces the customer
        ///     Console.WriteLine(customer.Value.Name);
        /// }
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Single", Justification = "It's used in loads of places by the linq extension methods as a method name.")]
        IInclude<T> Single<T>(object identifier) where T : class, new();

        /// <summary>
        /// Includes a single instance based upon the specified SQL query.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="sqlQuery">The SQL query to execute.</param>
        /// <returns>A pointer to the included instance of the specified type.</returns>
        /// <exception cref="ObjectDisposedException">Thrown if the session has been disposed.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the specified instance is null.</exception>
        /// <exception cref="MicroLiteException">Thrown if there is an error executing the query.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Single", Justification = "It's used in loads of places by the linq extension methods as a method name.")]
        IInclude<T> Single<T>(SqlQuery sqlQuery) where T : class, new();
    }
}