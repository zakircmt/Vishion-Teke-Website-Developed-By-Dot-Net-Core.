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
using VisionTake.ViewModels;

namespace VisionTake.Controllers
{
    public class VisionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;


        public VisionsController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Visions
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblVisions.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public IActionResult Vision()
        {
            VissionViwModel model = new VissionViwModel();
            model.TblVision = _context.TblVisions.Take(1).OrderByDescending(x => x.ID).ToList();
            return View(model);
        }

        // GET: Visions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblVision = await _context.TblVisions
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblVision == null)
                {
                    return NotFound();
                }

                return View(tblVision);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Visions/Create
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

        // POST: Visions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblVision tblVision)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblVision.ID = Guid.NewGuid();
                    tblVision.TimeStamp = DateTime.Now;
                    var uniqueFileName = UploadedFile(tblVision);
                    tblVision.ImageUrl = uniqueFileName;
                    _context.Add(tblVision);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblVision);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblVision slider)
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

        // GET: Visions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblVision = await _context.TblVisions.FindAsync(id);
                if (tblVision == null)
                {
                    return NotFound();
                }
                return View(tblVision);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Visions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Description,TimeStamp,ImageUrl")] TblVision tblVision)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblVision.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tblVision);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblVisionExists(tblVision.ID))
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
                return View(tblVision);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Visions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblVision = await _context.TblVisions
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblVision == null)
                {
                    return NotFound();
                }

                return View(tblVision);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Visions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblVision = await _context.TblVisions.FindAsync(id);
                _context.TblVisions.Remove(tblVision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblVisionExists(Guid id)
        {
            return _context.TblVisions.Any(e => e.ID == id);
        }
    }
}
