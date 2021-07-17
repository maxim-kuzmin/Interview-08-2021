namespace Homework.ApplicationLayer.RabbitMQ.Consumer.Worker
{
    /// <summary>
    /// Настройки конфигурации работника.
    /// </summary>
    public class WorkerConfigSettings : IWorkerConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public int ThreadCount { get; set; }

        #endregion Properties
    }
}
