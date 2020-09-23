using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 一级嵌套
            //IConfigurationBuilder builder = new ConfigurationBuilder();

            //builder.AddInMemoryCollection(new Dictionary<string, string>()
            //{
            //    { "key1","value1" },
            //    { "key2","value2" },
            //});
            //IConfigurationRoot configurationRoot = builder.Build();

            //Console.WriteLine($"key1:{configurationRoot["key1"]}");
            //Console.WriteLine($"key2:{configurationRoot["key2"]}");
            #endregion

            #region  二级嵌套
            //IConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddInMemoryCollection(new Dictionary<string, string>()
            //   {
            //       { "section1:key4","value4" },
            //       { "section2:key5","value5" },
            //   });
            //IConfigurationRoot configurationRoot = builder.Build();

            //IConfigurationSection section = configurationRoot.GetSection("section1");
            //IConfigurationSection section2 = configurationRoot.GetSection("section2");
            //Console.WriteLine($"key4:{section["key4"]}");
            //Console.WriteLine($"key5:{section2["key5"]}");
            #endregion

            #region  多级嵌套
            //IConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddInMemoryCollection(new Dictionary<string, string>()
            //{
            //    { "section2:key6","value6" },
            //    { "section2:section3:key7","value7" }
            //});

            //IConfigurationSection section2 = configurationRoot.GetSection("section2");
            //Console.WriteLine($"key5_v2:{section2["key5"]}");
            //var section3 = section2.GetSection("section3");
            //Console.WriteLine($"key7:{section3["key7"]}");
            #endregion
        }
    }
}
