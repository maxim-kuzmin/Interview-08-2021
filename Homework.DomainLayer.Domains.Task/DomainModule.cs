using Homework.InfrastructureLayer.Common;
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
                x.GetRequiredService<ILogger<DomainService>>()
                ));
        }

        #endregion Public methods
    }
}
