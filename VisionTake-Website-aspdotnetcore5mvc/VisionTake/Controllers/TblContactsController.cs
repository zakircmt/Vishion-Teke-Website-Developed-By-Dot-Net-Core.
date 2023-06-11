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
    public class TblContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TblContacts
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblContacts.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TblContact tblContact)
        {
            if (ModelState.IsValid)
            {
                tblContact.ID = Guid.NewGuid();
                tblContact.TimeStamp = DateTime.Now;
                _context.Add(tblContact);
                await _context.SaveChangesAsync();
                ViewBag.message = "Your has been sent and the authorities will contact you.";
                return RedirectToAction("Index","Home");
            }
            return View(tblContact);
        }


        //[HttpPost]
        //public void Create(TblContact tblContact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        tblContact.ID = Guid.NewGuid();
        //        tblContact.TimeStamp = DateTime.Now;
        //        _context.Add(tblContact);
        //        _context.SaveChangesAsync();
        //        ViewBag.message = "Your has been sent and the authorities will contact you.";

        //    }
        //}


        private bool TblContactExists(Guid id)
        {
            return _context.TblContacts.Any(e => e.ID == id);
        }
    }
}
