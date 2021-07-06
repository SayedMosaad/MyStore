using Microsoft.Extensions.DependencyInjection;
using MyStore.Application.Services;
using MyStore.Application.Interfaces;
using MyStore.Infra.Data.Repositories;
using MyStore.Domain.Interfaces;


namespace MyStore.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //to register Application Layer
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            //to register Infra.Data Layer
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
