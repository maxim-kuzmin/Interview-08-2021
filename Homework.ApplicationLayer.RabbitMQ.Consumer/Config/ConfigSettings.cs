using Homework.ApplicationLayer.RabbitMQ.Consumer.Worker;
using IRabbitMQConfigSettings = Homework.ApplicationLayer.RabbitMQ.Config.IConfigSettings;
using RabbitMQConfigSettings = Homework.ApplicationLayer.RabbitMQ.Config.ConfigSettings;

namespace Homework.ApplicationLayer.RabbitMQ.Consumer.Config
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

        /// <summary>
        /// Работник.
        /// </summary>
        public WorkerConfigSettings Worker { get; set; }

        /// <inheritdoc/>
        IRabbitMQConfigSettings IConfigSettings.RabbitMQ => RabbitMQ;

        /// <inheritdoc/>
        IWorkerConfigSettings IConfigSettings.Worker => Worker;

        #endregion Properties
    }
}
