using Contracts;
using MyShop.Services.AdminService;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService;
using MyShop.Services.BuyerService.Contracts;
using MyShop.Services.SellerService;
using MyShop.Services.SellerService.Contracts;
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

        public static void ConfigurationSellerServiceManager(this IServiceCollection services)
        {
            services.AddScoped<ISellerServiceManager, SellerServiceManager>();
        }
    }
}
