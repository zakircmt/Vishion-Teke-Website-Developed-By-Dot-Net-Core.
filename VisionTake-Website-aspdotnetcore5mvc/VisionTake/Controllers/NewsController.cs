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
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public NewsController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblNewses.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public async Task<IActionResult> News()
        {
            return View(await _context.TblNewses.ToListAsync());
        }
        public async Task<IActionResult> Detail(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNews = await _context.TblNewses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblNews == null)
            {
                return NotFound();
            }

            return View(tblNews);

        }
        // GET: News/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblNews = await _context.TblNewses
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblNews == null)
                {
                    return NotFound();
                }

                return View(tblNews);

            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: News/Create
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

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblNews tblNews)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblNews.ID = Guid.NewGuid();
                    tblNews.CreateDate = DateTime.Now;
                    tblNews.UpdateDate = DateTime.Now;
                    tblNews.TimeStamp = DateTime.Now;
                    var uniqueFileName = UploadedFile(tblNews);
                    tblNews.ImageUrl = uniqueFileName;
                    _context.Add(tblNews);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblNews);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblNews slider)
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
        // GET: News/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblNews = await _context.TblNewses.FindAsync(id);
                if (tblNews == null)
                {
                    return NotFound();
                }
                return View(tblNews);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, TblNews tblNews)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblNews.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblNews.ImageUrl == null && tblNews.MyProperty != null) || (tblNews.ImageUrl != null && tblNews.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblNews);
                            tblNews.ImageUrl = uniqueFileName;
                            _context.Update(tblNews);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblNews);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblNewsExists(tblNews.ID))
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
                return View(tblNews);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: News/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblNews = await _context.TblNewses
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblNews == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblNews);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: News/Delete/5
        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblNews = await _context.TblNewses.FindAsync(id);
                _context.TblNewses.Remove(tblNews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblNewsExists(Guid id)
        {
            return _context.TblNewses.Any(e => e.ID == id);
        }
    }
}
