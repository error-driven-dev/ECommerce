using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: null, template: "{category}/Page{pageNum:int}",
                    defaults: new {controller = "Product", action = "ProductDirectory"});
                routes.MapRoute(name: null, template: "Page{pageNum:int}",
                    defaults: new {controller = "Product", action = "ProductDirectory", pageNum = 1});
                routes.MapRoute(name: null, template: "",
                    defaults: new {controller = "Product", action = "ProductDirectory", pageNum1 = 1});
                routes.MapRoute(null, "{controller=Product}/{action=ProductDirectory}/{id?}");

            });
            
            SeedData.EnsurePopulated(app);
        }
    }
}
