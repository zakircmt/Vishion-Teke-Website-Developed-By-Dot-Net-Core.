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
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public ReviewsController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblReviews
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblReviews.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public async Task<IActionResult> Review()
        {
            return View(await _context.TblReviews.ToListAsync());
        }
        // GET: TblReviews/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblReview = await _context.TblReviews
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblReview == null)
                {
                    return NotFound();
                }

                return View(tblReview);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblReviews/Create
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

        // POST: TblReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(TblReview tblReview)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblReview.ID = Guid.NewGuid();
                    var uniqueFileName = UploadedFile(tblReview);
                    tblReview.ImageUrl = uniqueFileName;
                    _context.Add(tblReview);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblReview);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        public string UploadedFile(TblReview slider)
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

        // GET: TblReviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblReview = await _context.TblReviews.FindAsync(id);
                if (tblReview == null)
                {
                    return NotFound();
                }
                return View(tblReview);

            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Designation,Review,ImageUrl")] TblReview tblReview)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblReview.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblReview.ImageUrl == null && tblReview.MyProperty != null) || (tblReview.ImageUrl != null && tblReview.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblReview);
                            tblReview.ImageUrl = uniqueFileName;
                            _context.Update(tblReview);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblReview);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblReviewExists(tblReview.ID))
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
                return View(tblReview);

            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblReviews/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblReview = await _context.TblReviews
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblReview == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblReview);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: TblReviews/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblReview = await _context.TblReviews.FindAsync(id);
                _context.TblReviews.Remove(tblReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblReviewExists(Guid id)
        {
            return _context.TblReviews.Any(e => e.ID == id);
        }
    }
}
