using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Areas.Docs.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Input));
        }
        public IActionResult Input()
        {
            return View();
        }
    }
}