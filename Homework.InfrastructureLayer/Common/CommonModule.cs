using Microsoft.Extensions.DependencyInjection;

namespace Homework.InfrastructureLayer.Common
{
    /// <summary>
    /// Общий модуль.
    /// </summary>
    public abstract class CommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public abstract void ConfigureServices(IServiceCollection services);

        #endregion Public methods
    }
}
