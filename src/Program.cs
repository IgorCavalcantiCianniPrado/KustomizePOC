using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;

namespace KustomizePocConsole
{
    internal class Program
    {
        private static IConfiguration configuration;

        static void Main(string[] args)
        {
            BuildConfiguration();

            var propriedade1 = configuration.GetSection("propriedades:prop1").Value;
            var propriedade2 = configuration.GetSection("propriedades:prop2").Value;
            var propriedade3 = configuration.GetSection("propriedades:prop3").Value;

            while (true)
            {          
                Console.WriteLine($"VALOR PROPRIEDADE 1: {propriedade1}");
                Console.WriteLine($"VALOR PROPRIEDADE 2: {propriedade2}");
                Console.WriteLine($"VALOR PROPRIEDADE 3: {propriedade3}");
                Thread.Sleep(2000);
            }
        }

        private static void BuildConfiguration()
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .Build();
        }
    }
}
