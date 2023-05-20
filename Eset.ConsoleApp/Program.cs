using Eset.LogParser;
using Eset.LogParser.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Eset.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var app = serviceProvider.GetService<App>();
            app.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IEsetLogParser, EsetLogParser>();
            services.AddTransient<IEsetFileOpener, EsetFileOpener>();
            services.AddTransient<IEsetFileInfo, EsetFileInfo>();
            services.AddTransient<IEsetLogParserHelper, EsetLogParserHelper>();
            services.AddTransient<App>();

            return services.BuildServiceProvider();
        }

        public class App
        {
            private readonly IEsetLogParser _esetLogParser;

            public App(IEsetLogParser esetLogParser)
            {
                _esetLogParser = esetLogParser;
            }

            public void Run()
            {
                _esetLogParser.ParseLogFile("EsetSampleLog.log", Console.Out);
                
            }
        }
    }
}