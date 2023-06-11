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
    public class PartnerCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public PartnerCategoriesController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblPartnerCategories
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblPartnerCategories.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblPartnerCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblPartnerCategory = await _context.TblPartnerCategories
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblPartnerCategory == null)
                {
                    return NotFound();
                }

                return View(tblPartnerCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblPartnerCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPartnerCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(TblPartnerCategory tblPartnerCategory)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblPartnerCategory.ID = Guid.NewGuid();
                    var uniqueFileName = UploadedFile(tblPartnerCategory);
                    tblPartnerCategory.ImageUrl = uniqueFileName;
                    _context.Add(tblPartnerCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblPartnerCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        public string UploadedFile(TblPartnerCategory slider)
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

        // GET: TblPartnerCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblPartnerCategory = await _context.TblPartnerCategories.FindAsync(id);
                if (tblPartnerCategory == null)
                {
                    return NotFound();
                }
                return View(tblPartnerCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblPartnerCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id,TblPartnerCategory tblPartnerCategory)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblPartnerCategory.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblPartnerCategory.ImageUrl == null && tblPartnerCategory.MyProperty != null) || (tblPartnerCategory.ImageUrl != null && tblPartnerCategory.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblPartnerCategory);
                            tblPartnerCategory.ImageUrl = uniqueFileName;
                            _context.Update(tblPartnerCategory);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblPartnerCategory);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblPartnerCategoryExists(tblPartnerCategory.ID))
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
                return View(tblPartnerCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblPartnerCategories/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblPartnerCategory = await _context.TblPartnerCategories
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblPartnerCategory == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblPartnerCategory);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: TblPartnerCategories/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblPartnerCategory = await _context.TblPartnerCategories.FindAsync(id);
                _context.TblPartnerCategories.Remove(tblPartnerCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblPartnerCategoryExists(Guid id)
        {
            return _context.TblPartnerCategories.Any(e => e.ID == id);
        }
    }
}
