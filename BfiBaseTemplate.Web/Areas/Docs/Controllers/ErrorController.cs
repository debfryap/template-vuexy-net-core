using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Areas.Docs.Controllers
{
    [Area("docs")]
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(NotFound));
        }
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult NotAuthorize()
        {
            return View();
        }
        public IActionResult UnderConstruction()
        {
            return View();
        }
    }
}