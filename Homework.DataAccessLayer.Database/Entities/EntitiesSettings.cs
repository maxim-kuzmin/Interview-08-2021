// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Entities.Task;

namespace Homework.DataAccessLayer.Database.Entities
{
    /// <summary>
    /// Настройки сущностей.
    /// </summary>
    public abstract class EntitiesSettings
    {
        #region Properties

        /// <summary>
        /// Сущность "Задача".
        /// </summary>
        public TaskEntitySettings Task { get; protected set; }

        #endregion Properties
    }
}

