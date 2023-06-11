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
    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public SubCategoriesController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblSubCategories
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var applicationDbContext = _context.TblSubCategories.Include(t => t.TblCategory);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblSubCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblSubCategory = await _context.TblSubCategories
                    .Include(t => t.TblCategory)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblSubCategory == null)
                {
                    return NotFound();
                }

                return View(tblSubCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblSubCategories/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                ViewData["TblCategoryID"] = new SelectList(_context.TblCategories, "ID", "CategoryName");
                return View();
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(TblSubCategory tblSubCategory)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblSubCategory.ID = Guid.NewGuid();
                    var uniqueFileName = UploadedFile(tblSubCategory);
                    tblSubCategory.ImageUrl = uniqueFileName;
                    _context.Add(tblSubCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["TblCategoryID"] = new SelectList(_context.TblCategories, "ID", "ID", tblSubCategory.TblCategoryID);
                return View(tblSubCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblSubCategory slider)
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

        // GET: TblSubCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblSubCategory = await _context.TblSubCategories.FindAsync(id);
                if (tblSubCategory == null)
                {
                    return NotFound();
                }
                ViewData["TblCategoryID"] = new SelectList(_context.TblCategories, "ID", "CategoryName", tblSubCategory.TblCategoryID);
                return View(tblSubCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,TblSubCategory tblSubCategory)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblSubCategory.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblSubCategory.ImageUrl == null && tblSubCategory.MyProperty != null) || (tblSubCategory.ImageUrl != null && tblSubCategory.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblSubCategory);
                            tblSubCategory.ImageUrl = uniqueFileName;
                            _context.Update(tblSubCategory);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblSubCategory);
                            await _context.SaveChangesAsync();
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblSubCategoryExists(tblSubCategory.ID))
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
                ViewData["TblCategoryID"] = new SelectList(_context.TblCategories, "ID", "ID", tblSubCategory.TblCategoryID);
                return View(tblSubCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblSubCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblSubCategory = await _context.TblSubCategories
                    .Include(t => t.TblCategory)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblSubCategory == null)
                {
                    return NotFound();
                }

                return View(tblSubCategory);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblSubCategories/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblSubCategory = await _context.TblSubCategories.FindAsync(id);
                _context.TblSubCategories.Remove(tblSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblSubCategoryExists(Guid id)
        {
            return _context.TblSubCategories.Any(e => e.ID == id);
        }
    }
}
