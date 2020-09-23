using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    class MyMiddleware
    {
        RequestDelegate _next;
        ILogger _logger;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("开始执行了!");
            await _next(context);
            Console.WriteLine("执行结束");
        }
    }
}
