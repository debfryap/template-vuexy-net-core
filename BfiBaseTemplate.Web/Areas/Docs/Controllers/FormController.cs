using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Areas.Docs.Controllers
{
    [Area("docs")]
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
        public IActionResult Select()
        {
            return View();
        }
        public IActionResult Radio()
        {
            return View();
        }
        public IActionResult Datepicker()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
    }
}