using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.Interface;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Infraestructure.SQLServer;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Application;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Application.Interface;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Infraestructure;

namespace ControlDolarPeru.Api.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            services.AddTransient<IHistoricalAverageAggregate, HistoricalAverageAggregate>();
            services.AddTransient<IHistoricalAverageRepository, HistoricalAverageRepository>();
            services.AddTransient<IConfigurationLinksAggregate, ConfigurationLinksAggregate>();
            services.AddTransient<IConfigurationLinksRepository, ConfigurationLinksRepository>();
            return services;
        }
    }
}
