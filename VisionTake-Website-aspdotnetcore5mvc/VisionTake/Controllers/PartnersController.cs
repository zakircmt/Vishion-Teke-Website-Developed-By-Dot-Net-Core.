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
    public class PartnersController : Controller
    {
        private readonly ApplicationDbContext _context ;
        private readonly IWebHostEnvironment _webHost;

        public PartnersController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Partners
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblPartners.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public IActionResult Partner(Guid? ID)
        {
            var partners = _context.TblPartners.Where(x => x.TblPartnerCategoryID == ID).ToList().OrderByDescending(x => x.ID);
            return View(partners);
         }
        public async Task<IActionResult> Partners()
        {
            return View(await _context.TblPartners.ToListAsync());
        }
        // GET: Partners/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblPartner = await _context.TblPartners
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblPartner == null)
                {
                    return NotFound();
                }

                return View(tblPartner);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                CreatePartnersViewModel model = new CreatePartnersViewModel();
                model.PartnerCategories = _context.TblPartnerCategories.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePartnersViewModel model)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    model.ID = Guid.NewGuid();
                    TblPartner partner = new TblPartner();
                    partner.ID = model.ID;
                    partner.ImageUrl = model.ImageUrl;
                    partner.TblPartnerCategoryID = model.TblPartnerCategoryID;
                    partner.TimeStamp = DateTime.Now;
                    var uniqueFileName = UploadedFile(model);
                    partner.ImageUrl = uniqueFileName;
                    _context.Add(partner);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        public string UploadedFile(CreatePartnersViewModel slider)
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
        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblPartner = await _context.TblPartners.FindAsync(id);
                ViewData["TblPartnerCategoryID"] = new SelectList(_context.TblPartnerCategories, "ID", "Name",tblPartner.TblPartnerCategoryID);
                if (tblPartner == null)
                {
                    return NotFound();
                }
                return View(tblPartner);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id,TblPartner tblPartner)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblPartner.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblPartner.ImageUrl == null && tblPartner.MyProperty != null) || (tblPartner.ImageUrl != null && tblPartner.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFiles(tblPartner);
                            tblPartner.ImageUrl = uniqueFileName;
                            _context.Update(tblPartner);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblPartner);
                            await _context.SaveChangesAsync();
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblPartnerExists(tblPartner.ID))
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
                ViewData["TblPartnerCategoryID"] = new SelectList(_context.TblPartnerCategories, "ID", "ID", tblPartner.TblPartnerCategoryID);
                return View(tblPartner);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        public string UploadedFiles(TblPartner slider)
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
        // GET: Partners/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblPartner = await _context.TblPartners
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblPartner == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblPartner);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: Partners/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblPartner = await _context.TblPartners.FindAsync(id);
                _context.TblPartners.Remove(tblPartner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblPartnerExists(Guid id)
        {
            return _context.TblPartners.Any(e => e.ID == id);
        }
    }
}
