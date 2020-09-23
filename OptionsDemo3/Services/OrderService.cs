﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace OptionsDemo.Services
{
    public interface IOrderService
    {
        int ShowMaxOrderCount();
    }
    public class OrderService : IOrderService
    {
        IOptionsMonitor<OrderServiceOptions> _options;
        public OrderService(IOptionsMonitor<OrderServiceOptions> options)
        {
            _options = options;

            //_options.OnChange(option =>
            //{
            //    Console.WriteLine($"配置更新了，最新的值是:{_options.CurrentValue.MaxOrderCount}");
            //});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ShowMaxOrderCount()
        {
            return _options.CurrentValue.MaxOrderCount;
        }
    }

    public class OrderServiceOptions
    {
        //public int MaxOrderCount { get; set; } = 100;

        [Range(1,80)]
        public int MaxOrderCount { get; set; } = 100;
    }

    public class OrderServiceValidateOptions : IValidateOptions<OrderServiceOptions>
    {
        public ValidateOptionsResult Validate(string name, OrderServiceOptions options)
        {
            if (options.MaxOrderCount > 20)
            {
                return ValidateOptionsResult.Fail("MaxOrderCount 不能大于20");
            }
            else
            {
                return ValidateOptionsResult.Success;
            }
        }
    }
}

