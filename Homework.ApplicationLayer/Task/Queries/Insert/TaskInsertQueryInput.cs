// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Homework.ApplicationLayer.Task.Queries.Insert
{
    /// <summary>
    /// Входные данные запроса на вставку задачи.
    /// </summary>
    public class TaskInsertQueryInput
    {
        #region Properties

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        #endregion Properties
    }
}
