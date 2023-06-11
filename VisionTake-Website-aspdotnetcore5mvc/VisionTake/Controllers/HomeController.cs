using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Data;
using VisionTake.Entities;
using VisionTake.Models;
using VisionTake.Services;
using VisionTake.ViewModels;

namespace VisionTake.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            MasterLayoutViewModels model = new MasterLayoutViewModels();
            model.Sliders = GetFiveSlider();
            model.TblAbout = _context.TblAbouts.Take(1).OrderByDescending(x => x.ID).ToList();
            model.TblEvent = _context.TblEvent.Take(12).OrderByDescending(x => x.ID).ToList();
            model.TblProduct = _context.TblProducts.Take(12).OrderByDescending(x => x.ID).ToList();
            model.TblReview = _context.TblReviews.Take(6).OrderByDescending(x => x.ID).ToList();
            model.TblPatent = _context.TblPatents.Take(8).OrderByDescending(x => x.ID).ToList();
            model.TblPartner = _context.TblPartners.Take(12).OrderByDescending(x => x.ID).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<TblSlider> GetFiveSlider()
        {
            var sliderList = _context.TblSliders.Take(5).OrderByDescending(x => x.ID).ToList();
            return sliderList;
        }

    }
}
