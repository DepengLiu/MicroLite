﻿// -----------------------------------------------------------------------
// <copyright file="IConfigureExtensions.cs" company="MicroLite">
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
namespace MicroLite.Configuration
{
    using System;
    using MicroLite.Logging;

    /// <summary>
    /// The interface which specifies the options for configuring extensions to the MicroLite ORM framework.
    /// </summary>
    public interface IConfigureExtensions : IHideObjectMethods
    {
        /// <summary>
        /// Sets the function which can be called by MicroLite to resolve the <see cref="ILog"/> to use.
        /// </summary>
        /// <param name="logResolver">The function to resolve an ILog.</param>
        void SetLogResolver(Func<string, ILog> logResolver);
    }
}