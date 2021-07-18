// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Homework.DataAccessLayer.Database.Entities.Task
{
    /// <summary>
    /// Объект сущности "Задача".
    /// </summary>
    public class TaskEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime Dt { get; set; }

        #endregion Properties
    }
}
