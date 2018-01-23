using Microsoft.AspNetCore.Hosting;

namespace SicherheitCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = WebHostDefaults.
            //            .UseStartup<Startup>()
            //            .Build();
            //host.Run();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();

        //public static IWebHost BuildWebHost(string[] args)
        //{
        //    //var serviceCollection = new ServiceCollection();
        //    //serviceCollection.AddSingleton<ILogger, SimplyLogger>();
        //    //var serviceProvider = serviceCollection.BuildServiceProvider();
        //    return new WebHostBuilder()
        //                .UseStartup<Startup>()
        //                //.ConfigureServices(s =>
        //                //{
        //                //    s.AddSingleton<ILogger, SimplyLogger>();
        //                //    s.AddMvc();
        //                //})
        //                .Build();
        //}
    }
}
