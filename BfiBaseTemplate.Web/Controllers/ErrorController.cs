using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Controllers
{
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
    }
}