using IRabbitMQConfigSettings = Homework.ApplicationLayer.RabbitMQ.Config.IConfigSettings;
using RabbitMQConfigSettings = Homework.ApplicationLayer.RabbitMQ.Config.ConfigSettings;

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
        public RabbitMQConfigSettings RabbitMQ { get; set; }

        /// <inheritdoc/>
        IRabbitMQConfigSettings IConfigSettings.RabbitMQ => RabbitMQ;

        #endregion Properties
    }
}
