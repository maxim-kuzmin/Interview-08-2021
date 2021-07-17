using Homework.InfrastructureLayer.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Homework.ApplicationLayer.RabbitMQ.Producer
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
                new Module()
            });
        }

        #endregion Public methods
    }
}
