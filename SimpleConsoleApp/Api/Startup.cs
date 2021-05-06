using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Data;
using Data.Repository;
using Domain.Configuration;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            var config = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables();


            if (!configuration["Environment"].Equals("DEV", StringComparison.CurrentCultureIgnoreCase))
            {

#if DEBUG
                config
                    .AddJsonFile("appsettings.json", true)
                    .AddJsonFile("appsettings.Development.json", true);
#endif

            }

            _configuration = config.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(o => { })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            var config = _configuration
                .GetSection("ApiConfiguration")
                .Get<ApiConfiguration>();

            services.AddDbContext<PersonDataContext>(options=>options.UseSqlServer(config.ConnectionString),ServiceLifetime.Transient);
            
            
            //services.AddDbContext<PersonDataContext>(options => options.UseInMemoryDatabase("SimpleApi"), ServiceLifetime.Transient);

            services.AddTransient<IPersonDataContext, PersonDataContext>();
            
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IFormatService, FormatService>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleApi", Version = "v1" });
                c.SwaggerDoc("operations", new OpenApiInfo { Title = "Simple Api operations" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleApi");
                c.RoutePrefix = string.Empty;
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseEndpoints(builder =>
            {
                builder.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=People}/{action=GetAll}/{id?}");
            });
        }
    }
}