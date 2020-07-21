using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PanelDashboard.Repo.Entities.Request;

namespace PanelDashboard.Web.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterEntitiesRequest model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("index", "verification");
            }
            return View();
        }
    }
}