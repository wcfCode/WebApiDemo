using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;

namespace ConfigurationFileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 基本操作
            //var builder = new ConfigurationBuilder( );
            //builder.AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            //builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            //var configurationRoot = builder.Build();

            //Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            //Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            //Console.WriteLine($"Key3:{configurationRoot["Key3"]}");
            //Console.ReadKey();
            //Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            //Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            //Console.WriteLine($"Key3:{configurationRoot["Key3"]}");
            #endregion

            #region 监听对象的变更
            //var builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //var configurationRoot = builder.Build();
            //IChangeToken token = configurationRoot.GetReloadToken();

            //ChangeToken.OnChange(() => configurationRoot.GetReloadToken(), () =>
            //{
            //    Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            //    Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            //    Console.WriteLine($"Key3:{configurationRoot["Key3"]}");
            //});
            #endregion

            #region 将配置映射到实体
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");

            var configurationRoot = builder.Build();

            var config = new Config();
            configurationRoot.GetSection("OrderService").Bind(config);

            configurationRoot.GetSection("OrderService").Bind(config,
                binderOptions => { binderOptions.BindNonPublicProperties = true; });

            Console.WriteLine($"Key1:{config.Key1}");
            Console.WriteLine($"Key5:{config.Key5}");
            Console.WriteLine($"Key6:{config.Key6}");

            #endregion 

            Console.ReadKey();
        }



        class Config
        {
            public string Key1 { get; set; }
            public bool Key5 { get; set; }
            //public int Key6 { get; set; }

            public int Key6 { get; private set; }
        }
    }
}
