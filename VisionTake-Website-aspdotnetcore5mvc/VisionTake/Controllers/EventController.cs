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
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public EventController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblEvent.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            } 
        }
        public async Task<IActionResult> EventList()
        {
            return View(await _context.TblEvent.ToListAsync());
        }
        public async Task<IActionResult> Detail(Guid? id)
        {
                if (id == null)
                {
                    return NotFound();
                }

                var tblEvent = await _context.TblEvent
                    .FirstOrDefaultAsync(m => m.ID == id);
                ViewBag.AllSlider = _context.TblSliders.ToList().OrderByDescending(x => x.ID);
                if (tblEvent == null)
                {
                    return NotFound();
                }

                return View(tblEvent);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblEvent = await _context.TblEvent
                    .FirstOrDefaultAsync(m => m.ID == id);
                ViewBag.AllSlider = _context.TblSliders.ToList().OrderByDescending(x => x.ID);
                if (tblEvent == null)
                {
                    return NotFound();
                }

                return View(tblEvent);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Event/Create
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

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblEvent tblEvent)
        {
           

            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblEvent.ID = Guid.NewGuid();
                    tblEvent.TimeStamp = DateTime.Now;
                    var uniqueFileName = UploadedFile(tblEvent);
                    tblEvent.ImageUrl = uniqueFileName;
                    _context.Add(tblEvent);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblEvent);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }

        }
        public string UploadedFile(TblEvent slider)
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

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblEvent = await _context.TblEvent.FindAsync(id);
                if (tblEvent == null)
                {
                    return NotFound();
                }
                return View(tblEvent);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TblEvent tblEvent)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblEvent.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblEvent.ImageUrl == null && tblEvent.MyProperty != null) || (tblEvent.ImageUrl != null && tblEvent.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblEvent);
                            tblEvent.TimeStamp = DateTime.Now;
                            tblEvent.ImageUrl = uniqueFileName;
                            _context.Update(tblEvent);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            tblEvent.TimeStamp = DateTime.Now;
                            _context.Update(tblEvent);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblEventExists(tblEvent.ID))
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
                return View(tblEvent);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Event/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblEvent = await _context.TblEvent
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblEvent == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblEvent);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: Event/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblEvent = await _context.TblEvent.FindAsync(id);
                _context.TblEvent.Remove(tblEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblEventExists(Guid id)
        {
            return _context.TblEvent.Any(e => e.ID == id);
        }
    }
}
