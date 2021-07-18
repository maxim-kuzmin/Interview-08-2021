// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Homework.ApplicationLayer.RabbitMQ.Producer.Config
{
    /// <summary>
    /// Настройки конфигурации.
    /// </summary>
    public class ConfigSettings : IConfigSettings
    {
        #region Properties

        /// <summary>
        /// Брокер сообщений RabbitMQ.
        /// </summary>
        public RabbitMQ.Config.ConfigSettings RabbitMQ { get; set; }

        /// <inheritdoc/>
        RabbitMQ.Config.IConfigSettings IConfigSettings.RabbitMQ => RabbitMQ;

        #endregion Properties
    }
}
