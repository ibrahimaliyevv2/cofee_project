using CofeeProject.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CofeeProject
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
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options =>
            {
                object value = options.UseSqlServer(@"Server=DESKTOP-FCKEBID\SQLEXPRESS01;Database=CofeeDB;Trusted_Connection=TRUE");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   "areas",
                   "{area:exists}/{controller=home}/{action=index}/{id?}"
                   );

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=home}/{action=index}/{id?}"
                    );

            });
        }
    }
}