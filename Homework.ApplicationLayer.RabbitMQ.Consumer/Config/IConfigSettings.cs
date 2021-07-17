using Homework.ApplicationLayer.RabbitMQ.Consumer.Worker;

namespace Homework.ApplicationLayer.RabbitMQ.Consumer.Config
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
        ApplicationLayer.RabbitMQ.Config.IConfigSettings RabbitMQ { get; }

        /// <summary>
        /// Работник.
        /// </summary>
        IWorkerConfigSettings Worker { get; }

        #endregion Properties
    }
}
