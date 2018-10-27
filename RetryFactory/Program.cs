using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RetryFactory
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The .NET Core webhost builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).
                UseUrls("http://0.0.0.0:5000") // to expose container ports https://docs.docker.com/v17.09/engine/userguide/networking/default_network/binding/
                .UseStartup<Startup>();
        }
    }
}