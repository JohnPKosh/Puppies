using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Puppies.Web
{
  /// <summary>
  /// Program class of the application that creates Host Builder and executes Startup
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Main entry point method of the application
    /// </summary>
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    /// <summary>
    /// Method to build the hosting model and launch Startup.cs
    /// </summary>
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
  }
}
