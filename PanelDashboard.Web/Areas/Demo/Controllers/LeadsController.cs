using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PanelDashboard.Web.Areas.Demo.Controllers
{
    public class LeadsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Input));
        }
        public IActionResult Input()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
    }
}