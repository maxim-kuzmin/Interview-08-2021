// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Db
{
    /// <summary>
    /// Фабрика базы данных клиента. Предназначена для выполнения команд dotnet ef, например:
    /// dotnet ef migrations add --configuration Debug -- "строка подключения к базе данных"
    /// dotnet ef database update --configuration Debug -- "строка подключения к базе данных"
    /// </summary>
    public class ClientDbFactory : IDesignTimeDbContextFactory<ClientDbContext>
    {
        #region Public methods

        /// <inheritdoc/>
        public ClientDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ClientDbContext> builder = new();

            Configure(builder, args.Length > 0 ? args[0] : null);
            
            return new ClientDbContext(builder.Options);
        }

        /// <summary>
        /// Настроить.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        /// <param name="connectionString">Строка подключения.</param>
        public static void Configure(DbContextOptionsBuilder builder, string connectionString)
        {
            if (builder.IsConfigured)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            builder.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)
                );
        }

        #endregion Public methods
    }
}
