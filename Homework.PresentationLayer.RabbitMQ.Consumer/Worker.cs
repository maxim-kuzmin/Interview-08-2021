using Homework.ApplicationLayer.RabbitMQ.Consumer;
using Homework.ApplicationLayer.RabbitMQ.Consumer.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.PresentationLayer.RabbitMQ.Consumer
{
    /// <summary>
    /// Работник.
    /// </summary>
    public class Worker : BackgroundService
    {
        #region Properties

        private IWorkerConfigSettings ConfigSettings { get; }

        private IService Service { get; }

        private ILogger Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Настройки конфигурации.</param>
        /// <param name="service">Сервис.</param>
        /// <param name="logger">Регистратор.</param>
        public Worker(IWorkerConfigSettings configSettings, IService service, ILogger<Worker> logger)
        {
            ConfigSettings = configSettings;

            Service = service;

            Logger = logger;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("Work started");

            var threadNumbers = Enumerable.Range(1, ConfigSettings.ThreadCount);

            foreach (var threadNumber in threadNumbers)
            {
                Task.Factory.StartNew(() => Run(threadNumber, stoppingToken), TaskCreationOptions.LongRunning);
            }

            stoppingToken.WaitHandle.WaitOne();

            return Task.CompletedTask;
        }

        #endregion Protected methods

        #region Private methods

        private void Run(int threadNumber, CancellationToken stoppingToken)
        {
            Logger.LogInformation("Thread #{0} started", threadNumber);

            try
            {
                Service.InsertTasks(threadNumber, stoppingToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, null);
            }
        }

        #endregion Private methods
    }
}
