﻿namespace MicroLite
{
    /// <summary>
    /// The supported types of strategy used to manage a row identifier.
    /// </summary>
    public enum IdentifierStrategy
    {
        /// <summary>
        /// The identifier value is generated by the database upon insert.
        /// </summary>
        DbGenerated = 0,

        /// <summary>
        /// The identifier value is assigned by user code prior to insert.
        /// </summary>
        Assigned = 1,
    }
}