// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Db;

namespace Homework.DataAccessLayer.Database.Entity
{
    /// <inheritdoc/>
    public class EntitySettings : DataLayer.Entity.EntitySettings<DbDefaults>
    {
        #region Constructors

        /// <inheritdoc/>
        public EntitySettings(DbDefaults defaults, string dbTable, string dbSchema = null)
            : base(defaults, dbTable, dbSchema)
        {
        }

        #endregion Constructors
    }
}
