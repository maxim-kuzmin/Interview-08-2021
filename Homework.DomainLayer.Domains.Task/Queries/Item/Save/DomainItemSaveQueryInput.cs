// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Entities.Task;

namespace Homework.DomainLayer.Domains.Task.Queries.Item.Save
{
    /// <summary>
    /// Входные данные запроса на сохранение элемента в домене.
    /// </summary>
    public class DomainItemSaveQueryInput
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Задача".
        /// </summary>
        public TaskEntityObject ObjectOfTaskEntity { get; set; }

        #endregion Properties
    }
}
