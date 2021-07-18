// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Db;
using Homework.InfrastructureLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Homework.DataAccessLayer.Database.Clients.PostgreSql.EF
{
    public class ClientModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<ClientDbContext>((x, options) => ClientDbFactory.Configure(
                options,
                x.GetRequiredService<IConfiguration>().GetConnectionString("Database")
                ));
        }

        /// <inheritdoc/>
        public override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IDbContextFactory<ClientDbContext>)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(IConfiguration)
            };
        }

        #endregion Protected methods
    }
}
