using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Materializer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                       .ConfigureHostConfiguration((config) =>
                       {
                           config.AddEnvironmentVariables();
                       })
                       .ConfigureAppConfiguration((hostContext, config) =>
                       {
                           config.SetBasePath(Environment.CurrentDirectory);
                           config.AddJsonFile("appsettings.json", optional: false);
                           config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                           config.AddEnvironmentVariables();
                       })
                       .ConfigureServices((hostContext, services) =>
                        {
                            var serviceProvider = services.BuildServiceProvider();

                            services.AddMassTransit(x =>
                            {
                                x.AddConsumer<OrderMaterializerConsumer>();

                                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                                {
                                    var host = cfg.Host("localhost", "/", h => {
                                        h.Username("guest");
                                        h.Password("guest");
                                    });

                                    cfg.ReceiveEndpoint(host, "order.materializer", e =>
                                    {
                                        e.ConfigureConsumer<OrderMaterializerConsumer>(provider);
                                    });

                                }));

                                services.AddScoped<IHostedService, MassTransitBusControlService>();

                                services.AddDbContext<OrderReadDbContext>(config => {
                                    config.UseSqlServer(hostContext.Configuration.GetConnectionString("OrderReadConnectionString"));
                                });

                                services.AddDbContext<OrderWriteDbContext>(config => {
                                    config.UseSqlServer(hostContext.Configuration.GetConnectionString("OrderWriteConnectionString"));
                                });
                            });

                        });

            await hostBuilder.RunConsoleAsync();
        }

    }
}
