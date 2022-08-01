using Application.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Services;
using Infrastructure.Services.FilesStorage;
using Infrastructure.Services.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace PouyanSiteStore
{
    public static class ServicesQueue
    {

        public static IServiceCollection ServicesQueues(this IServiceCollection services)
        {
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IProduct, Product>();
            services.AddScoped<ICartItem, CartItem>();
            services.AddScoped<IModule, Module>();
            services.AddScoped<ISlider, Slider>();
            services.AddScoped<ITransaction, Transaction>();
            services.AddTransient<IFileUploader, FileUploader>();
            return services;
        }

    }
}
