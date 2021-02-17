using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

    public IActionResult Index()
    {
      return View(_puppyDao.GetPuppies());
    }

  }
}
