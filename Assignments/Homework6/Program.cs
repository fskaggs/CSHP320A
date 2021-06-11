//CSHP320A
//Frederick J. Skaggs - Homework 6

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Homework6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
