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
    public class PatentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public PatentsController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblPatents
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblPatents.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public async Task<IActionResult> PatentList()
        {
            return View(await _context.TblPatents.ToListAsync());
        }
        // GET: TblPatents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblPatent = await _context.TblPatents
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblPatent == null)
                {
                    return NotFound();
                }

                return View(tblPatent);

            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblPatents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPatents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblPatent tblPatent)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblPatent.ID = Guid.NewGuid();
                    var uniqueFileName = UploadedFile(tblPatent);
                    tblPatent.ImageUrl = uniqueFileName;
                    _context.Add(tblPatent);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblPatent);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblPatent slider)
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

        // GET: TblPatents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblPatent = await _context.TblPatents.FindAsync(id);
                if (tblPatent == null)
                {
                    return NotFound();
                }
                return View(tblPatent);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblPatents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id,TblPatent tblPatent)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblPatent.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblPatent.ImageUrl == null && tblPatent.MyProperty != null) || (tblPatent.ImageUrl != null && tblPatent.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblPatent);
                            tblPatent.ImageUrl = uniqueFileName;
                            _context.Update(tblPatent);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblPatent);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblPatentExists(tblPatent.ID))
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
                return View(tblPatent);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblPatents/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblPatent = await _context.TblPatents
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblPatent == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblPatent);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: TblPatents/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblPatent = await _context.TblPatents.FindAsync(id);
                _context.TblPatents.Remove(tblPatent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblPatentExists(Guid id)
        {
            return _context.TblPatents.Any(e => e.ID == id);
        }
    }
}
