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
                    Console.WriteLine("ִ�з�����ConfigureHostConfiguration");
                })
                .ConfigureServices(services =>
                {
                    Console.WriteLine("ִ�з�����ConfigureServices");
                })
                .ConfigureLogging(loggingBuilder =>
                {
                    Console.WriteLine("ִ�з�����ConfigureLogging");
                })
                .ConfigureAppConfiguration((hostBuilderContext, configurationBinder) =>
                {
                    Console.WriteLine("ִ�з�����ConfigureAppConfiguration");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("ִ�з�����ConfigureWebHostDefaults");
                    //webBuilder.UseStartup<Startup>();

                    webBuilder.ConfigureServices(services =>
                    {
                        Console.WriteLine("ִ�з�����webBuilder.ConfigureServices");
                        //services.AddMvc();
                        // services.AddAuthentication()
                        services.AddControllers();

                    });

                    webBuilder.Configure(app =>
                    {
                        Console.WriteLine("ִ�з�����webBuilder.Configure");

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
