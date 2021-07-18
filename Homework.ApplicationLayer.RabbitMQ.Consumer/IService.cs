// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading;

namespace Homework.ApplicationLayer.RabbitMQ.Consumer
{
    /// <summary>
    /// Интерфейс сервиса.
    /// </summary>
    public interface IService
    {
        #region Methods

        /// <summary>
        /// Вставить задачи.
        /// </summary>
        /// <param name="threadNumber">Номер потока.</param>
        /// <param name="stoppingToken">Токен остановки.</param>
        void InsertTasks(int threadNumber, CancellationToken stoppingToken);

        #endregion Methods
    }
}
