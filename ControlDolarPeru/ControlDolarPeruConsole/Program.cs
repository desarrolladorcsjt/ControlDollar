using ControlDolarPeru;
using ControlDolarPeru.Api.Extensions;
using ControlDolarPeru.Console;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.DTO;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.Interface;
using ControlDolarPeru.Domain.EF;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Application.Interface;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.ServiceWorker;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

 class Program
{
        static IConfiguration SetConfiguration( )
        {
            IConfigurationBuilder configurationBuilder;
            configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettingsConsole.json");
            return configurationBuilder.Build();
        }
        static async Task Main()
        {
             Console.WriteLine("Inicio la consola");
            IConfiguration configuration = SetConfiguration();
            using ServiceProvider service = DependencyInyectionConfiguration(configuration);
            IHistoricalAverageAggregate historicalAverageAggregate = service.GetService<IHistoricalAverageAggregate>();
            IConfigurationLinksAggregate configurationLinksAggregate = service.GetService<IConfigurationLinksAggregate>();
            var list = configurationLinksAggregate?.Get();
            Console.WriteLine("Se obtuvo la lista de entidades ");
            Console.WriteLine(list);
            var res =Scraping.ScrapingWeb(list);
            Console.WriteLine("Se realizo el screaping");
            Console.WriteLine(JsonConvert.SerializeObject(res));
            historicalAverageAggregate?.Create(res);
            service.Dispose();
        }

        static ServiceProvider DependencyInyectionConfiguration(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(configuration);
            services.AddDbContext<DollarContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DolarDb"),
                sqlServerOptionsAction: builder =>
                {
                    builder.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null);
                });
            });
        DIExtensions.AddConfigurations(services);
        return services.BuildServiceProvider();
        }
        
  
}