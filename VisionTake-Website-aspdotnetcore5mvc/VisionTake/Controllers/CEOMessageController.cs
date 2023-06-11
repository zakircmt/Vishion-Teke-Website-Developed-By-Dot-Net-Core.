using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Controllers
{
    public class CEOMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
