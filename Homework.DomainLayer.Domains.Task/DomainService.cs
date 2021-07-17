using Homework.DomainLayer.Domains.Task.Queries.Item.Save;
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

        private ILogger<DomainService> Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        public DomainService(ILogger<DomainService> logger)
        {
            Logger = logger;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<DomainSaveItemQueryOutput> SaveItem(DomainSaveItemQueryInput input)
        {
            DomainSaveItemQueryOutput result = new();

            result.ObjectOfTaskEntity = input.ObjectOfTaskEntity;

            // Задержка в 5 секунд имитирует долгое сохранение задачи в базе данных.
            await SystemTask.Delay(5000).ConfigureAwait(false);

            Logger.LogInformation(
                "Saved a task with id = {0} and description = {1}",
                input.ObjectOfTaskEntity.Id,
                input.ObjectOfTaskEntity.Description
                );

            return result;
        }

        #endregion Public methods
    }
}
