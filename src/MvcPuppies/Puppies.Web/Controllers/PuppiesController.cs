using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Puppies.Web.DAL;
using Puppies.Web.Models;

namespace Puppies.Web.Controllers
{
  /// <summary> The Puppies Controller is responsible for listing all pups, details, and saving new pup </summary>
  public class PuppiesController : Controller
  {
    private readonly ILogger<PuppiesController> _logger;

    private readonly IPuppyDao _puppyDao;

    /// <summary> The default constructor which accepts an ILogger and IPuppyDao through DI in Startup</summary>
    public PuppiesController(ILogger<PuppiesController> logger, IPuppyDao puppyDao)
    {
      _logger = logger;
      _puppyDao = puppyDao;
    }

    // GET: Puppies
    public IActionResult Index()
    {
      try
      {
#if DEBUG
        _logger.LogInformation("GET Puppies Index called");  // TODO: Implement full logging solution when building production app
#endif
        return View(_puppyDao.GetPuppies());
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "{0} - {1}", "Puppies/Index", ex.Message);
        return View();
      }      
    }

    // GET: Puppies/Details/1
    public ActionResult Detail(int id)
    {      
      try
      {
#if DEBUG
        _logger.LogInformation("GET Puppies/Details/{0} called", id); // TODO: Implement full logging solution when building production app
#endif
        return View(_puppyDao.GetPuppy(id));
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "{0} - {1}", "Puppies/Details/Id", ex.Message);
        return View();
      }
    }

    // POST: Puppies/Save
    [HttpPost("Index")]
    [ValidateAntiForgeryToken]
    public ActionResult Save([Bind("Name,Weight,Gender,PaperTrained")] Puppy pup)
    {
      try
      {
#if DEBUG
        _logger.LogInformation("POST: Puppies Save called for {0}", pup.Name);  // TODO: Implement full logging solution when building production app
#endif
        if (!ModelState.IsValid)
        {
          ViewData.Add("NoName", 1);
          return View("Index", _puppyDao.GetPuppies());
        }
        _puppyDao.SavePuppy(pup);
        return RedirectToAction("Index");
      }
      catch(Exception ex)
      {
        _logger.LogError(ex, "{0} - {1}", "Puppies/Save", ex.Message);
        return View();
      }
    }

  }
}
