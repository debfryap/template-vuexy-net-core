using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BfiBaseTemplate.Web.Areas.Docs.Controllers
{
    [Area("docs")]
    public class ModalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}