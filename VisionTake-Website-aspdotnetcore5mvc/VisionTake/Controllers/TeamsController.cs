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
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public TeamsController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblTeams
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblTeams.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public async Task<IActionResult> Team()
        {
            return View(await _context.TblTeams.ToListAsync());
        }
        // GET: TblTeams/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblTeam = await _context.TblTeams
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblTeam == null)
                {
                    return NotFound();
                }

                return View(tblTeam);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: TblTeams/Create
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

        // POST: TblTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblTeam tblTeam)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblTeam.ID = Guid.NewGuid();
                    tblTeam.TimeStamp = System.DateTime.Now;
                    var uniqueFileName = UploadedFile(tblTeam);
                    tblTeam.ImageUrl = uniqueFileName;
                    _context.Add(tblTeam);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblTeam);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblTeam slider)
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

        // GET: TblTeams/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblTeam = await _context.TblTeams.FindAsync(id);
                if (tblTeam == null)
                {
                    return NotFound();
                }
                return View(tblTeam);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: TblTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, TblTeam tblTeam)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblTeam.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblTeam.ImageUrl == null && tblTeam.MyProperty != null) || (tblTeam.ImageUrl != null && tblTeam.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblTeam);
                            tblTeam.ImageUrl = uniqueFileName;
                            _context.Update(tblTeam);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblTeam);
                            await _context.SaveChangesAsync();
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblTeamExists(tblTeam.ID))
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
                return View(tblTeam);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        //// GET: TblTeams/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblTeam = await _context.TblTeams
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblTeam == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblTeam);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: TblTeams/Delete/5
        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblTeam = await _context.TblTeams.FindAsync(id);
                _context.TblTeams.Remove(tblTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblTeamExists(Guid id)
        {
            return _context.TblTeams.Any(e => e.ID == id);
        }
    }
}
