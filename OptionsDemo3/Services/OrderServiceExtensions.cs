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

            #region 添加验证
            services.AddOptions<OrderServiceOptions>().Configure(options =>
            {
                configuration.Bind(options);

            }).Validate(options => options.MaxOrderCount > 100, "MaxOrderCount 不能大于一百");


            //属性的方式
            //services.AddOptions<OrderServiceOptions>().Configure(options =>
            //{
            //    configuration.Bind(options);

            //}).ValidateDataAnnotations();

            //实现接口模式
            //services.AddOptions<OrderServiceOptions>().Configure(options =>
            //{
            //    configuration.Bind(options);
            //}).Services.AddSingleton<IValidateOptions<OrderServiceOptions>>(new OrderServiceValidateOptions());
            #endregion

            services.AddSingleton<IOrderService, OrderService>();
            return services;
        }
    }
}
