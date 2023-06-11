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
    public class MissionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public MissionController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Mission
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblMissions.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public IActionResult Mission()
        {
            MissionViewModels model = new MissionViewModels();
            TblMission mission = new TblMission();
            model.Description = mission.Description;
            model.ImageUrl = mission.ImageUrl;
            model.TblMission = _context.TblMissions.Take(1).OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        // GET: Mission/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblMission = await _context.TblMissions
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblMission == null)
                {
                    return NotFound();
                }

                return View(tblMission);

            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Mission/Create
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

        // POST: Mission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblMission tblMission)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblMission.ID = Guid.NewGuid();
                    tblMission.TimeStamp = DateTime.Now;
                    var uniqueFileName = UploadedFile(tblMission);
                    tblMission.ImageUrl = uniqueFileName;
                    _context.Add(tblMission);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblMission);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(TblMission slider)
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

        // GET: Mission/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblMission = await _context.TblMissions.FindAsync(id);
                if (tblMission == null)
                {
                    return NotFound();
                }
                return View(tblMission);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Mission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TblMission tblMission)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblMission.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblMission.ImageUrl == null && tblMission.MyProperty != null) || (tblMission.ImageUrl != null && tblMission.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFile(tblMission);
                            tblMission.ImageUrl = uniqueFileName;
                            _context.Update(tblMission);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblMission);
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblMissionExists(tblMission.ID))
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
                return View(tblMission);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Mission/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblMission = await _context.TblMissions
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblMission == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblMission);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        //// POST: Mission/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        var tblMission = await _context.TblMissions.FindAsync(id);
        //        _context.TblMissions.Remove(tblMission);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        private bool TblMissionExists(Guid id)
        {
            return _context.TblMissions.Any(e => e.ID == id);
        }
    }
}
