using Homework.ApplicationLayer.RabbitMQ.Consumer.Config;
using Homework.ApplicationLayer.RabbitMQ.Consumer.Worker;
using Homework.DomainLayer.Domains.Task;
using Homework.InfrastructureLayer.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Homework.ApplicationLayer.RabbitMQ.Consumer
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(CreateAppConfigSettings);

            services.AddSingleton(x => x.GetRequiredService<IConfigSettings>().RabbitMQ);

            services.AddSingleton(x => x.GetRequiredService<IConfigSettings>().Worker);

            services.AddSingleton<IService>(x => new Service(
                x.GetRequiredService<ApplicationLayer.RabbitMQ.Config.IConfigSettings>(),
                x.GetRequiredService<IDomainService>(),
                x.GetRequiredService<ILogger<Service>>()
                ));
        }

        #endregion Public methods

        #region Private methods

        private IConfigSettings CreateAppConfigSettings(IServiceProvider serviceProvider)
        {
            ConfigSettings result = new();

            serviceProvider.GetRequiredService<IConfiguration>().GetSection("App").Bind(result);

            return result;
        }

        #endregion Private methods
    }
}
