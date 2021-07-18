// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.ApplicationLayer.RabbitMQ.Consumer.Config;
using Homework.DomainLayer.Domains.Task;
using Homework.DomainLayer.Domains.Task.Queries.Item.Save;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using SystemTask = System.Threading.Tasks.Task;

namespace Homework.ApplicationLayer.RabbitMQ.Consumer
{
    /// <summary>
    /// Сервис.
    /// </summary>
    public class Service : IService
    {
        #region Fields

        private int _idOfTaskEntity = 0;

        private readonly ConnectionFactory _connectionFactory;

        #endregion Fields

        #region Properties

        private IConfigSettings ConfigSettings { get; }

        private IDomainService DomainService { get; }

        private ILogger Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Настройки конфигурации.</param>
        /// <param name="domainService">Сервис домена.</param>
        /// <param name="logger">Регистратор.</param>
        public Service(
            IConfigSettings configSettings,
            IDomainService domainService,
            ILogger<Service> logger
            )
        {
            ConfigSettings = configSettings;

            DomainService = domainService;

            Logger = logger;

            _connectionFactory = new() { HostName = ConfigSettings.RabbitMQ.HostName };
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void InsertTasks(int threadNumber, CancellationToken stoppingToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: ConfigSettings.RabbitMQ.Queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            Logger.LogInformation("The thread #{0} is waiting for messages", threadNumber);

            EventingBasicConsumer consumer = new(channel);

            consumer.Received += async (s, e) => await OnReceived(s, e, threadNumber).ConfigureAwait(false);

            channel.BasicConsume(queue: ConfigSettings.RabbitMQ.Queue, autoAck: false, consumer: consumer);

            stoppingToken.WaitHandle.WaitOne();
        }

        #endregion Public methods

        #region Private methods

        private async SystemTask OnReceived(object sender, BasicDeliverEventArgs e, int threadNumber)
        {
            byte[] body = e.Body.ToArray();

            string message = Encoding.UTF8.GetString(body);

            Interlocked.Increment(ref _idOfTaskEntity);

            Logger.LogInformation("The thread #{0} received a task description {1}", threadNumber, message);

            await DomainService.SaveItem(new DomainItemSaveQueryInput
            {
                ObjectOfTaskEntity = new()
                {
                    Id = _idOfTaskEntity,
                    Description = message
                }
            }).ConfigureAwait(false);

            ((EventingBasicConsumer)sender).Model.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
        }

        #endregion Private methods
    }
}
