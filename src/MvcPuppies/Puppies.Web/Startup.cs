using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Puppies.Web.DAL;

namespace Puppies.Web
{
  /// <summary> The bootstrap hosting startup class </summary>
  public class Startup
  {
    const string CONN_STR = "Data Source=DEVHOME\\DEV2019;Initial Catalog=module3assessment;Integrated Security=True;";

    /// <summary> The Startup class constructor called by Program.cs host builder method to inject service configuration </summary>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary> Key/Value pair configuration collection property of the application </summary>
    public IConfiguration Configuration { get; }

    /// <summary> This method gets called by the runtime. Use this method to add services to the container. </summary>
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddLogging(logging =>
      {
        logging.AddConfiguration(Configuration.GetSection("Logging"));
        logging.AddConsole();
      });

      // Inject IPuppyDao with concrete PuppySqlDao with ILogger<PuppySqlDao> and CONN_STR
      var serviceProvider = services.BuildServiceProvider();
      var m_Logger = serviceProvider.GetService<ILogger<PuppySqlDao>>();
      services.AddTransient<IPuppyDao, PuppySqlDao>(s => new PuppySqlDao(m_Logger, CONN_STR));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    /// <summary> This method gets called by the runtime. Use this method to configure the HTTP request pipeline. </summary>
    public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "{controller=Puppies}/{action=Index}/{id?}");
      });
    }
  }
}
