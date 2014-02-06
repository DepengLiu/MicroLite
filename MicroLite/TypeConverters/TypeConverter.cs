﻿// -----------------------------------------------------------------------
// <copyright file="TypeConverter.cs" company="MicroLite">
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
namespace MicroLite.TypeConverters
{
    using System;

    /// <summary>
    /// The base class for any implementation of <see cref="ITypeConverter"/>.
    /// </summary>
    public abstract class TypeConverter : ITypeConverter
    {
        private static readonly TypeConverterCollection converters = new TypeConverterCollection();
        private static readonly ITypeConverter defaultConverter = new ObjectTypeConverter();

        /// <summary>
        /// Gets the type converter collection which contains all type converters registered with the MicroLite ORM framework.
        /// </summary>
        public static TypeConverterCollection Converters
        {
            get
            {
                return converters;
            }
        }

        /// <summary>
        /// Gets the default type converter which can be used if there is no specific type converter for a given type.
        /// </summary>
        public static ITypeConverter Default
        {
            get
            {
                return defaultConverter;
            }
        }

        /// <summary>
        /// Gets the <see cref="ITypeConverter"/> for the specified type.
        /// </summary>
        /// <param name="type">The type to get the converter for.</param>
        /// <returns>The <see cref="ITypeConverter"/> for the specified type, or null if no specific type converter exists for the type.</returns>
        /// <remarks>
        /// If For returns null, the TypeConverter.Default can be used.
        /// </remarks>
        public static ITypeConverter For(Type type)
        {
            for (int i = 0; i < Converters.Count; i++)
            {
                var typeConverter = Converters[i];

                if (typeConverter.CanConvert(type))
                {
                    return typeConverter;
                }
            }

            return null;
        }

        /// <summary>
        /// Determines whether this type converter can convert values for the specified property type.
        /// </summary>
        /// <param name="propertyType">The type of the property value to be converted.</param>
        /// <returns>
        ///   <c>true</c> if this instance can convert the specified property type; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool CanConvert(Type propertyType);

        /// <summary>
        /// Converts the specified database value into an instance of the property type.
        /// </summary>
        /// <param name="value">The database value to be converted.</param>
        /// <param name="propertyType">The property type to convert to.</param>
        /// <returns>
        /// An instance of the specified property type containing the specified value.
        /// </returns>
        public abstract object ConvertFromDbValue(object value, Type propertyType);

        /// <summary>
        /// Converts the specified property value into an instance of the database value.
        /// </summary>
        /// <param name="value">The property value to be converted.</param>
        /// <param name="propertyType">The property type to convert from.</param>
        /// <returns>
        /// An instance of the corresponding database type for the property type containing the property value.
        /// </returns>
        public abstract object ConvertToDbValue(object value, Type propertyType);
    }
}