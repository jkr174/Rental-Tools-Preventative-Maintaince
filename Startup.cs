using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheDeepO.Models;

namespace TheDeepO
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:TheDeepOInventories:ConnectionString"]));

            //services.AddDbContext<AppIdentityDbContext>

            services.AddTransient<IInventoryRepository, EFInventoryRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: null,
                    template: "{controller=Inventory}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{inventoryPage:int}",
                    defaults: new { Controller = "Inventory", action = "List" });

                routes.MapRoute(
                    name: null,
                    template: "Page{inventoryPage:int}",
                    defaults: new { Controller = "Inventory", action = "List", inventoryPage = 1 });
                
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { Controller = "Inventory", action = "List", inventoryPage = 1 });
                routes.MapRoute(
                    name: null,
                    template: "{category}/{subcategory}",
                    defaults: new { Controller = "Inventory", action = "List", inventoryPage = 1 });
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { Controller = "Inventory", action = "List", inventoryPage = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}