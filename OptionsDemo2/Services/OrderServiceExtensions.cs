using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptionsDemo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OrderServiceExtensions
    {
        public static IServiceCollection AddOrderService(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<OrderServiceOptions>(configuration);
            services.PostConfigure<OrderServiceOptions>(options =>
            {
                options.MaxOrderCount += 20;
            });
            services.AddSingleton<IOrderService, OrderService>();
            return services;
        }
    }
}
