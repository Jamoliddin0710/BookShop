using Contracts.RepositoryContract;
using MyShop.Services.AdminService;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService;
using MyShop.Services.BuyerService.Contracts;
using Repository;

namespace MyShop.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurationRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigurationBuyerServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IBuyerServiceManager, BuyerServiceManager>();
        }
    }
}
