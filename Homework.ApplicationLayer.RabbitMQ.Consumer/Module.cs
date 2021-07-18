// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Homework.ApplicationLayer.RabbitMQ.Consumer.Config;
using Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Db;
using Homework.DataAccessLayer.Database.Mappers.EF.Db;
using Homework.DomainLayer.Domains.Task;
using Homework.InfrastructureLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

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
            services.AddLocalization(options =>
            {
                CommonConfigurator.ConfigureLocalization(options);
            });

            services.AddSingleton(CreateConfigSettings);

            services.AddTransient<IDbContextFactory<MapperDbContext>>(x =>
                x.GetRequiredService<IDbContextFactory<ClientDbContext>>()
                );

            services.AddSingleton<IService>(x => new Service(
                x.GetRequiredService<IConfigSettings>(),
                x.GetRequiredService<IDomainService>(),
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
                typeof(IDbContextFactory<MapperDbContext>),
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
                typeof(IDbContextFactory<ClientDbContext>),
                typeof(IDomainService),
                typeof(ILogger)
            };
        }

        #endregion Protected methods

        #region Private methods

        private IConfigSettings CreateConfigSettings(IServiceProvider serviceProvider)
        {
            ConfigSettings result = new();

            serviceProvider.GetRequiredService<IConfiguration>().GetSection("App").Bind(result);

            return result;
        }

        #endregion Private methods
    }
}
