// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Db;
using Homework.DataAccessLayer.Database.Entity;

namespace Homework.DataAccessLayer.Database.Entities.Task
{
    /// <summary>
    /// Настройки сущности "Задача".
    /// </summary>
    public class TaskEntitySettings : EntitySettings
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Description".
        /// </summary>
        public string DbColumnForDescription { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dbDefaults">Значения по умолчанию  в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public TaskEntitySettings(
            DbDefaults dbDefaults,
            string dbTable,
            string dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForId = dbDefaults.DbColumnForId;

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
