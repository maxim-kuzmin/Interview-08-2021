using Homework.DomainLayer.Domains.Task.Queries.Item.Save;
using System.Threading.Tasks;

namespace Homework.DomainLayer.Domains.Task
{
    /// <summary>
    /// Интерфейс сервиса домена.
    /// </summary>
    public interface IDomainService
    {
        #region Public methods

        /// <summary>
        /// Сохранить элемент.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<DomainSaveItemQueryOutput> SaveItem(DomainSaveItemQueryInput input);

        #endregion Public methods
    }
}
