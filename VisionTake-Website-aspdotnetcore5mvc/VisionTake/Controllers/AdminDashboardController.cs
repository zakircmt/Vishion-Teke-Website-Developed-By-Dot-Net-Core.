using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View();
            }
            else {
                return RedirectToAction("login","Auth");
            }
        }
    }
}
