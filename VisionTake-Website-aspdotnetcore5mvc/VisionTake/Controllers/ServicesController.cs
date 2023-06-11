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
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public ServicesController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblServices
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblServices.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public async Task<IActionResult> Services()
        {
            return View(await _context.TblServices.ToListAsync());
        }

        public async Task<IActionResult> Detail(Guid? id)
        {
             if (id == null)
             {
                 return NotFound();
             }

             var tblService = await _context.TblServices
                 .FirstOrDefaultAsync(m => m.ID == id);
             if (tblService == null)
             {
                 return NotFound();
             }

             return View(tblService);

        }

        // GET: TblServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblService = await _context.TblServices
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblService == null)
                {
                    return NotFound();
                }

                return View(tblService);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblServices/Create
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

        // POST: TblServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblService tblService)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblService.ID = Guid.NewGuid();
                    tblService.TimeStamp = DateTime.Now;
                    var uniqueFileName = UploadedFile(tblService);
                    tblService.ImageUrl = uniqueFileName;
                    _context.Add(tblService);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblService);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblService slider)
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

        // GET: TblServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblService = await _context.TblServices.FindAsync(id);
                if (tblService == null)
                {
                    return NotFound();
                }
                return View(tblService);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, TblService tblService)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblService.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblService.ImageUrl == null && tblService.MyProperty != null) || (tblService.ImageUrl != null && tblService.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblService);
                            tblService.ImageUrl = uniqueFileName;
                            _context.Update(tblService);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblService);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblServiceExists(tblService.ID))
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
                return View(tblService);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblServices/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblService = await _context.TblServices
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblService == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblService);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: TblServices/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblService = await _context.TblServices.FindAsync(id);
                _context.TblServices.Remove(tblService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblServiceExists(Guid id)
        {
            return _context.TblServices.Any(e => e.ID == id);
        }
    }
}
