// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.DataAccessLayer.Database.Mappers.EF.Db;
using Homework.DomainLayer.Domains.Task.Queries.Item.Save;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SystemTask = System.Threading.Tasks.Task;

namespace Homework.DomainLayer.Domains.Task
{
    /// <summary>
    /// Сервис домена.
    /// </summary>
    public class DomainService : IDomainService
    {
        #region Properties

        private IDbContextFactory<MapperDbContext> DbContextFactory { get; }

        private ILogger<DomainService> Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dbContextFactory">Фабрика контекста базы данных.</param>
        /// <param name="logger">Регистратор.</param>
        public DomainService(IDbContextFactory<MapperDbContext> dbContextFactory, ILogger<DomainService> logger)
        {
            DbContextFactory = dbContextFactory;

            Logger = logger;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<DomainItemSaveQueryOutput> SaveItem(DomainItemSaveQueryInput input)
        {
            DomainItemSaveQueryOutput result = new();

            result.ObjectOfTaskEntity = input.ObjectOfTaskEntity;

            using var dbContext = DbContextFactory.CreateDbContext();

            Logger.LogInformation(
                "Created a databse context with ConnectionString = {0}",
                dbContext.Database.GetConnectionString()
                );

            // Задержка в 5 секунд имитирует долгое сохранение задачи в базе данных.
            await SystemTask.Delay(5000).ConfigureAwait(false);

            Logger.LogInformation(
                "Saved a task with Id = {0} and Description = {1}",
                input.ObjectOfTaskEntity.Id,
                input.ObjectOfTaskEntity.Description
                );

            return result;
        }

        #endregion Public methods
    }
}
