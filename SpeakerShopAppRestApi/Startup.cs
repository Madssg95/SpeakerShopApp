using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpeakerShopApp.Core.ApplicationService.Impl;
using SpeakerShopApp.Core.ApplicationService.Service;
using SpeakerShopApp.Core.DomainService;
using SpeakerShopApp.Infrastructure.Data;
using SpeakerShopApp.Infrastructure.Data.Repositories;

namespace SpeakerShopAppRestApi
{
    public class Startup
    {
        private IConfiguration _conf { get; }
        private IHostingEnvironment _env { get; set; }


        public Startup(IConfiguration conf, IHostingEnvironment env)
        {
            _env = env;
            _conf = conf;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                _conf = builder.Build();



        }

       
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add CORS
            services.AddCors();

            if (_env.IsDevelopment())
            {
                services.AddDbContext<SpeakerShopAppContext>(
                opt => opt.UseSqlite("Data Source= SpeakerShop.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<SpeakerShopAppContext>(
                    opt => opt.UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<ISpeakerService, SpeakerService>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddMvc().AddJsonOptions(options =>
                                             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<SpeakerShopAppContext>();

                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<SpeakerShopAppContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }
            app.UseCors(b => b.WithOrigins("http://localhost:5001").AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}