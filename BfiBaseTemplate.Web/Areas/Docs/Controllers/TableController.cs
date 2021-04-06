using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Areas.Docs.Controllers
{
    [Area("docs")]
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Bordered));
        }
        public IActionResult Bordered()
        {
            return View();
        }
        public IActionResult Animation()
        {
            return View();
        }
        public IActionResult Striped()
        {
            return View();
        }
        public IActionResult Datatables()
        {
            return View();
        }
    }
}