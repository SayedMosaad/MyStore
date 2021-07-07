using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyStore.Application.Interfaces;
using MyStore.Application.Services;
using MyStore.Domain.Models;
using MyStore.Infra.Data.Context;
using MyStore.Infra.IOC;
using NToastNotify;

namespace MyStore.MVC
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration )
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                PreventDuplicates = true,
                CloseButton = true,
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyStoreDBConnection"));
            });
            services.AddMediatR(typeof(Startup));
            RegisterServices(services);
            services.AddScoped<ICategoryService, CategoryService>();
            
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "MyAdminArea",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}
