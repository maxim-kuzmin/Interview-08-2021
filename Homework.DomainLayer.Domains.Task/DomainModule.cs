// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Homework.DataAccessLayer.Database.Mappers.EF.Db;
using Homework.InfrastructureLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Homework.DomainLayer.Domains.Task
{
    /// <summary>
    /// Модуль домена.
    /// </summary>
    public class DomainModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainService>(x => new DomainService(
                x.GetRequiredService<IDbContextFactory<MapperDbContext>>(),
                x.GetRequiredService<ILogger<DomainService>>()
                ));
        }

        /// <inheritdoc/>
        public override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IDomainService)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(IDbContextFactory<MapperDbContext>),
                typeof(ILogger)
            };
        }

        #endregion Protected methods
    }
}
