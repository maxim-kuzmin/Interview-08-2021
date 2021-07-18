// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Homework.ApplicationLayer.RabbitMQ.Producer.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации.
    /// </summary>
    public interface IConfigSettings
    {
        #region Properties

        /// <summary>
        /// Брокер сообщений RabbitMQ.
        /// </summary>
        RabbitMQ.Config.IConfigSettings RabbitMQ { get; }

        #endregion Properties
    }
}
