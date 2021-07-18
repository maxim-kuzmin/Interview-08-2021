// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.ApplicationLayer.Task.Queries.Insert;

namespace Homework.ApplicationLayer.RabbitMQ.Producer
{
    /// <summary>
    /// Интерфейс сервиса.
    /// </summary>
    public interface IService
    {
        #region Methods

        /// <summary>
        /// Вставить задачу.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        void InsertTask(TaskInsertQueryInput input);

        #endregion Methods
    }
}
