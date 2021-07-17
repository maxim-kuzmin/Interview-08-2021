namespace Homework.ApplicationLayer.RabbitMQ.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации.
    /// </summary>
    public interface IConfigSettings
    {
        #region Properties

        /// <summary>
        /// Имя хоста.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Очередь.
        /// </summary>
        public string Queue { get; set; }

        #endregion Properties
    }
}
