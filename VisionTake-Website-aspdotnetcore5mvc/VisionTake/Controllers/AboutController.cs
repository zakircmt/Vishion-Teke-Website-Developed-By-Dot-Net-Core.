using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisionTake.Data;
using VisionTake.Entities;

namespace VisionTake.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public AboutController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: About
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblAbouts.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public IActionResult AboutUs()
        {
            return View( _context.TblAbouts.ToList().Take(1).First());
        }
        // GET: About/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
          if (id == null)
          {
              return NotFound();
          }

          var tblAbout = await _context.TblAbouts
              .FirstOrDefaultAsync(m => m.ID == id);
          ViewBag.AllSlider = _context.TblSliders.ToList().OrderByDescending(x => x.ID);
          if (tblAbout == null)
          {
              return NotFound();
          }

          return View(tblAbout);
        }

        // GET: About/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: About/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblAbout tblAbout)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    var uniqueFileName = UploadedFile(tblAbout);
                    tblAbout.ImageUrl = uniqueFileName;
                    tblAbout.ID = Guid.NewGuid();
                    _context.Add(tblAbout);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblAbout);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblAbout slider)
        {
            string uniqueFileName = null;
            if (slider.MyProperty != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + slider.MyProperty.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    slider.MyProperty.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
        // GET: About/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblAbout = await _context.TblAbouts.FindAsync(id);
                if (tblAbout == null)
                {
                    return NotFound();
                }
                return View(tblAbout);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: About/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TblAbout tblAbout)
        {

            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblAbout.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblAbout.ImageUrl == null && tblAbout.MyProperty!=null) || (tblAbout.ImageUrl != null && tblAbout.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblAbout);
                            tblAbout.ImageUrl = uniqueFileName;
                            _context.Update(tblAbout);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblAbout);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblAboutExists(tblAbout.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(tblAbout);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblAboutExists(Guid id)
        {
            return _context.TblAbouts.Any(e => e.ID == id);
        }
    }
}
