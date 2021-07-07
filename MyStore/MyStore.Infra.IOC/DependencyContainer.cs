using Microsoft.Extensions.DependencyInjection;
using MyStore.Application.Services;
using MyStore.Application.Interfaces;
using MyStore.Infra.Data.Repositories;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Core.Bus;
using MyStore.Infra.Bus;
using MediatR;
using MyStore.Domain.Commands;
using MyStore.Domain.CommandHandlers;
using MyStore.Infra.Data.Context;

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
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // to register Domain IMediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            //to register Domain Handler
            services.AddScoped<IRequestHandler<CreateCategoryCommand, bool>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<EditCategoryCommand, bool>, EditCategoryCommandHandler>();
            services.AddScoped<IRequestHandler<CreateProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<EditProductCommand, bool>, EdirProductCommandHandler>();

        }
    }
}
