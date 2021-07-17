﻿using Homework.ApplicationLayer.RabbitMQ.Config;
using Homework.ApplicationLayer.Task.Queries.Insert;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace Homework.ApplicationLayer.RabbitMQ.Producer
{
    /// <summary>
    /// Сервис.
    /// </summary>
    public class Service : IService
    {
        #region Fields

        private readonly ConnectionFactory _connectionFactory;

        #endregion Fields

        #region Properties

        private IConfigSettings ConfigSettings { get; }

        private ILogger Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Настройки конфигурации.</param>
        /// <param name="logger">Регистратор.</param>
        public Service(IConfigSettings configSettings, ILogger<Service> logger)
        {
            ConfigSettings = configSettings;

            Logger = logger;

            _connectionFactory = new ConnectionFactory() { HostName = ConfigSettings.HostName };
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void InsertTask(TaskInsertQueryInput input)
        {
            using var connection = _connectionFactory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: ConfigSettings.Queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(input.Description ?? string.Empty);

            var properties = channel.CreateBasicProperties();

            properties.Persistent = true;

            channel.BasicPublish(exchange: "", routingKey: ConfigSettings.Queue, basicProperties: properties, body: body);

            Logger.LogInformation("Sent a task description {0}", input.Description);
        }

        #endregion Public methods
    }
}
