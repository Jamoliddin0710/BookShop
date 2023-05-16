using Contracts;
using MyShop.Services.AdminService;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BookService;
using MyShop.Services.BookService.Contracts;
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

        public static void ConfigurationBuyerServiceMAnager(this IServiceCollection services)
        {
            services.AddScoped<IBuyerServiceManager, BuyerServiceManager>();
        }

        public static void ConfigurationSellerServiceManager(this IServiceCollection services)
        {
            services.AddScoped<ISellerServiceManager, SellerServiceManager>();
        }

  /*      public static void ConfigurationBuyerService(this IServiceCollection services)
        {
            services.AddScoped<ISellerService, SellerService>();
        }

        public static void ConfigurationSellerService(this IServiceCollection services)
        {
            services.AddScoped<ISellerService, SellerService>();
        }

        public static void ConfigurationBookService(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
        }

        public static void ConfigurationPublisherService(this IServiceCollection services)
        {
            services.AddScoped<IPublisherService, PublisherService>();
        }*/


    }
}
