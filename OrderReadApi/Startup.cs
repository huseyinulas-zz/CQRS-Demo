using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLOrder.Application.Orders.Queries;
using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace LNLOrder.ReadApi
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
            services.AddTransient<IQueryHandler<OrderPreviewQuery, List<OrderPreviewDto>>, OrderPreviewQueryHandler>();

            services.AddDbContext<IOrderReadDbContext, OrderReadDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("OrderReadConnectionString"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Order Read Api", Version = "v1" });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });

            app.UseMvc();
        }
    }
}
