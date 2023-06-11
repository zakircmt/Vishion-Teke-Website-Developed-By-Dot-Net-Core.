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
    public class SliderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public SliderController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Slider
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblSliders.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Slider/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSlider = await _context.TblSliders
                .FirstOrDefaultAsync(m => m.ID == id);
            ViewBag.AllSlider = _context.TblSliders.ToList().OrderByDescending(x => x.ID);
            if (tblSlider == null)
            {
                return NotFound();
            }

             return View(tblSlider);
        }

        // GET: Slider/Create
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

        // POST: Slider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TblSlider tblSlider)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblSlider.ID = Guid.NewGuid();
                    var uniqueFileName = UploadedFile(tblSlider);
                    tblSlider.ImageUrl = uniqueFileName;
                    //_context.Attach(tblSlider);
                    //_context.Entry(tblSlider).State = EntityState.Modified;
                    //_context.SaveChanges();
                    _context.Add(tblSlider);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblSlider);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblSlider slider)
        {
            string uniqueFileName = null;
            if (slider.MyProperty!=null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + slider.MyProperty.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream=new FileStream(filePath, FileMode.Create))
                {
                    slider.MyProperty.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
        // GET: Slider/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblSlider = await _context.TblSliders.FindAsync(id);
                if (tblSlider == null)
                {
                    return NotFound();
                }
                return View(tblSlider);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Slider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TblSlider tblSlider)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblSlider.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblSlider.ImageUrl == null && tblSlider.MyProperty!=null) || (tblSlider.ImageUrl != null && tblSlider.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblSlider);
                            tblSlider.ImageUrl = uniqueFileName;
                            _context.Update(tblSlider);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblSlider);
                            await _context.SaveChangesAsync();
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblSliderExists(tblSlider.ID))
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
                return View(tblSlider);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Slider/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblSlider = await _context.TblSliders
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (tblSlider == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tblSlider);
        //}

        // POST: Slider/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblSlider = await _context.TblSliders.FindAsync(id);
                _context.TblSliders.Remove(tblSlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblSliderExists(Guid id)
        {
            return _context.TblSliders.Any(e => e.ID == id);
        }
    }
}
