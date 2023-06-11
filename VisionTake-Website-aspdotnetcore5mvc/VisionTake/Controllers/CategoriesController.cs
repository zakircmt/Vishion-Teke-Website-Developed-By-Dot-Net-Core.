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
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public CategoriesController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblCategories
        public async Task<IActionResult> Index()
        {
           
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblCategories.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblCategory = await _context.TblCategories
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblCategory == null)
                {
                    return NotFound();
                }

                return View(tblCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblCategories/Create
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

        // POST: TblCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblCategory tblCategory)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblCategory.ID = Guid.NewGuid();
                    var uniqueFileName = UploadedFile(tblCategory);
                    tblCategory.ImageUrl = uniqueFileName;
                    _context.Add(tblCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblCategory slider)
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

        // GET: TblCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblCategory = await _context.TblCategories.FindAsync(id);
                if (tblCategory == null)
                {
                    return NotFound();
                }
                return View(tblCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TblCategory tblCategory)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblCategory.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblCategory.ImageUrl == null && tblCategory.MyProperty != null) || (tblCategory.ImageUrl != null && tblCategory.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblCategory);
                            tblCategory.ImageUrl = uniqueFileName;
                            _context.Update(tblCategory);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblCategory);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblCategoryExists(tblCategory.ID))
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
                return View(tblCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }


        // POST: TblCategories/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblCategory = await _context.TblCategories.FindAsync(id);
                _context.TblCategories.Remove(tblCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblCategoryExists(Guid id)
        {
            return _context.TblCategories.Any(e => e.ID == id);
        }
    }
}
