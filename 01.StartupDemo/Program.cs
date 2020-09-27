using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace _01.StartupDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureHostConfiguration(configurationBuilder =>
                {
                    Console.WriteLine("执行方法：ConfigureHostConfiguration");
                })
                .ConfigureServices(services =>
                {
                    Console.WriteLine("执行方法：ConfigureServices");
                })
                .ConfigureLogging(loggingBuilder =>
                {
                    Console.WriteLine("执行方法：ConfigureLogging");
                })
                .ConfigureAppConfiguration((hostBuilderContext, configurationBinder) =>
                {
                    Console.WriteLine("执行方法：ConfigureAppConfiguration");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("执行方法：ConfigureWebHostDefaults");
                    //webBuilder.UseStartup<Startup>();

                    webBuilder.ConfigureServices(services =>
                    {
                        Console.WriteLine("执行方法：webBuilder.ConfigureServices");
                        //services.AddMvc();
                        // services.AddAuthentication()
                        services.AddControllers();

                    });

                    webBuilder.Configure(app =>
                    {
                        Console.WriteLine("执行方法：webBuilder.Configure");

                        app.UseHttpsRedirection();

                        app.UseRouting();

                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });

                });
    }
}
