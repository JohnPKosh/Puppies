using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Puppies.Web.DAL;
using Puppies.Web.Models;

namespace Puppies.Web.Controllers
{
  public class PuppiesController : Controller
  {
    private readonly ILogger<PuppiesController> _logger;

    private readonly IPuppyDao _puppyDao;

    public PuppiesController(ILogger<PuppiesController> logger, IPuppyDao puppyDao)
    {
      _logger = logger;
      _puppyDao = puppyDao;
    }

    // GET: Puppies
    public IActionResult Index()
    {
      return View(_puppyDao.GetPuppies());
    }

    // GET: Puppies/Details/1
    public ActionResult Detail(int id)
    {
      return View(_puppyDao.GetPuppy(id));
    }

    // POST: Puppies/Save
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save([Bind("Name,Weight,Gender,PaperTrained")] Puppy pup)
    {
      try
      {
        _puppyDao.SavePuppy(pup);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

  }
}
