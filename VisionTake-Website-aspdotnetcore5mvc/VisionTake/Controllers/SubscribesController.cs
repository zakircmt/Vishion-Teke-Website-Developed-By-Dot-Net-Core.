using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisionTake.Data;
using VisionTake.Entities;

namespace VisionTake.Controllers
{
    public class SubscribesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscribesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblSubscribes
        public async Task<IActionResult> Index()
        {
            
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblSubscribes.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TblSubscribe tblSubscribe)
        {
            if (ModelState.IsValid)
            {
                tblSubscribe.ID = Guid.NewGuid();
                tblSubscribe.CreateDate = DateTime.Now;
                _context.Add(tblSubscribe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(tblSubscribe);
        }

        private bool TblSubscribeExists(Guid id)
        {
            return _context.TblSubscribes.Any(e => e.ID == id);
        }
    }
}
