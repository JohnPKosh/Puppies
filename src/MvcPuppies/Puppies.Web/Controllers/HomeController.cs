using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Puppies.Web.Models;

namespace Puppies.Web.Controllers
{
  /// <summary> The Home Controller is responsible to provide the Index, Privacy, and Error logic controller methods </summary>
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    /// <summary> The default constructor which accepts an ILogger through DI in Startup </summary>
    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    // GET: Home
    public IActionResult Index()
    {
#if DEBUG
      _logger.LogInformation("GET Home Index called");
#endif
      return View();
    }

    // GET: Privacy
    public IActionResult Privacy()
    {
#if DEBUG
      _logger.LogInformation("GET Home Privacy called");
#endif
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      var _errModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
#if DEBUG
      _logger.LogInformation("GET Home Error called - {0}", _errModel.RequestId);
#endif
      return View(_errModel);
    }
  }
}
