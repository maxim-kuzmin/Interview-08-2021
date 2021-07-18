// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.InfrastructureLayer.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Homework.ApplicationLayer.RabbitMQ.Consumer
{
    /// <summary>
    /// Конфигуратор.
    /// </summary>
    public static class Configurator
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            CommonConfigurator.ConfigureServices(services, new CommonModule[]
            {
                new DomainLayer.Domains.Task.DomainModule(),
                new Module()
            });
        }

        #endregion Public methods
    }
}
