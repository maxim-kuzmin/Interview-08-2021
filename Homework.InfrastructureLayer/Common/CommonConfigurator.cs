using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Homework.InfrastructureLayer.Common
{
    /// <summary>
    /// Общий конфигуратор.
    /// </summary>
    public static class CommonConfigurator
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="modules">Модули.</param>
        public static void ConfigureServices(IServiceCollection services, IEnumerable<CommonModule> modules)
        {
            foreach (var module in modules)
            {
                module.ConfigureServices(services);
            }
        }

        #endregion Public methods
    }
}
