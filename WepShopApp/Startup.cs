using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebShopApp.Core.Application_Service.Impl;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Infrastructure.Data;
using WebShopApp.Infrastructure.Data.Repositories;

namespace WepShopApp
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public IConfiguration _conf { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
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
            if (_env.IsDevelopment())
            {
                services.AddDbContext<WebShopAppContext>(
                    opt => opt.UseSqlite("Data Source=webShopApp.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<WebShopAppContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();



            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:63342").AllowAnyHeader()
                        .AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (IServiceScope scope = app.ApplicationServices.CreateScope())
                {
                    WebShopAppContext ctx = scope.ServiceProvider.GetService<WebShopAppContext>();
                   DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<WebShopAppContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

           app.UseHttpsRedirection();
           app.UseMvc();
        }
    }
}
