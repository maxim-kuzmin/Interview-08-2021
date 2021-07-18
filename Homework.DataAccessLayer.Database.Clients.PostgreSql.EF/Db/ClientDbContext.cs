// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Entities;
using Homework.DataAccessLayer.Database.Mappers.EF.Db;
using Homework.DataAccessLayer.Database.Mappers.EF.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Db
{
    /// <summary>
    /// Контекст базы данных клиента.
    /// </summary>
    public sealed class ClientDbContext : MapperDbContext
    {
        #region Constructors

        /// <inheritdoc/>
        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MapperTaskEntitySchema(ClientEntitiesSettings.Instance));
        }

        #endregion Protected methods
    }
}
