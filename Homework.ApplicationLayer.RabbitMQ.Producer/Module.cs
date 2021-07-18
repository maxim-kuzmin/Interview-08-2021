// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.ApplicationLayer.RabbitMQ.Producer.Config;
using Homework.InfrastructureLayer.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Homework.ApplicationLayer.RabbitMQ.Producer
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
            services.AddLocalization(options =>
            {
                CommonConfigurator.ConfigureLocalization(options);
            });

            services.AddSingleton(CreateAppConfigSettings);

            services.AddSingleton<IService>(x => new Service(
                x.GetRequiredService<IConfigSettings>(),
                x.GetRequiredService<ILogger<Service>>()
                ));
        }

        /// <inheritdoc/>
        public override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IConfigSettings),
                typeof(IConfiguration),
                typeof(ILogger),
                typeof(IService),
                typeof(IStringLocalizer)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(IConfigSettings),
                typeof(IConfiguration),
                typeof(ILogger)
            };
        }

        #endregion Protected methods

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
