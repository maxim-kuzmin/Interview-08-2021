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
        ApplicationLayer.RabbitMQ.Config.IConfigSettings RabbitMQ { get; }

        #endregion Properties
    }
}
