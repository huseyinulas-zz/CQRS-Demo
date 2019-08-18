using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LNLOrder.Application.Abstraction;
using LNLOrder.Infrastructure;
using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Application.Customers;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Application.Products;
using LNLOrder.Write.Persistance;
using Swashbuckle.AspNetCore.Swagger;
using LNLOrder.Write.Application.Orders;
using LNLOrder.Write.Application.Orders.Commands;
using LNLOrder.Application.Orders.Queries;
using System.Collections.Generic;

namespace LNLOrder.Write
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<RegisterCustomerCommand>, RegisterCustomerCommandHandler>();
            services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.AddTransient<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();

            services.AddTransient<INotificationService, NotificationService>();

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host("localhost", "/", p => { });
            }));

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            services.AddDbContext<IOrderWriteDbContext, OrderWriteDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("OrderWriteConnectionString"));
            });

            services.AddDbContext<IOrderReadDbContext, OrderReadDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("OrderReadConnectionString"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Order Write Api", Version = "v1" });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
