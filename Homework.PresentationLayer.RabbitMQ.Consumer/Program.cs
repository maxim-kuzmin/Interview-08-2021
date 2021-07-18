// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Homework.ApplicationLayer.RabbitMQ.Consumer;
using Homework.ApplicationLayer.RabbitMQ.Consumer.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Homework.PresentationLayer.RabbitMQ.Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    Configurator.ConfigureServices(services);

                    services.AddHostedService(x => new Worker(
                        x.GetRequiredService<IConfigSettings>(),
                        x.GetRequiredService<IService>(),
                        x.GetRequiredService<ILogger<Worker>>()
                        ));
                });
    }
}
