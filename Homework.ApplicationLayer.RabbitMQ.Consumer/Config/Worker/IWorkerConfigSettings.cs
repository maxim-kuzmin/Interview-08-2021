namespace Homework.ApplicationLayer.RabbitMQ.Consumer.Worker
{
    /// <summary>
    /// Интерфейс настроек конфигурации работника.
    /// </summary>
    public interface IWorkerConfigSettings
    {
        #region Properties

        /// <summary>
        /// Число потоков.
        /// </summary>
        public int ThreadCount { get; set; }

        #endregion Properties
    }
}
