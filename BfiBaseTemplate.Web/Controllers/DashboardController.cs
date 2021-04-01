using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("index", "dashboard", new { Area = "docs" });
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
