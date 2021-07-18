// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Homework.DataAccessLayer.Database.Db;
using Homework.DataAccessLayer.Database.Entities;
using Homework.DataAccessLayer.Database.Entities.Task;

namespace Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Entities
{
    /// <summary>
    /// Настройки сущностей клиента.
    /// </summary>
    internal class ClientEntitiesSettings : EntitiesSettings
    {
        #region Fields

        private static readonly Lazy<EntitiesSettings> _lazy = new(() => new ClientEntitiesSettings());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static EntitiesSettings Instance => _lazy.Value;

        #endregion Properties

        #region Constructors

        private ClientEntitiesSettings()
        {
            DbDefaults dbDefaults = new()
            {
                DbColumnForId = "id",
                DbColumnForName = "name",
                DbColumnForParentId = "parent_id",
                DbColumnForTreeChildCount = "tree_child_count",
                DbColumnForTreeDescendantCount = "tree_descendant_count",
                DbColumnForTreeLevel = "tree_level",
                DbColumnForTreePath = "tree_path",
                DbColumnForTreePosition = "tree_position",
                DbColumnForTreeSort = "tree_sort",
                DbColumnPartsSeparator = "_",
                DbForeignKeyPrefix = "fk",
                DbIndexPrefix = "ix",
                DbPrimaryKeyPrefix = "pk",
                DbSchema = "public",
                DbUniqueIndexPrefix = "ux",
                FullNamePartsSeparator = ".",
                NamePartsSeparator = "_"
            };

            Task = new TaskEntitySettings(dbDefaults, "task");
        }

        #endregion Constructors     
    }
}
