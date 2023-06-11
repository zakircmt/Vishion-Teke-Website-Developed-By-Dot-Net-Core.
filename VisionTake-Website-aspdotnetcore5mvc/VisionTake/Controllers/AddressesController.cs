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
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                return View(await _context.TblAddresses.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        //// GET: Addresses/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblAddress = await _context.TblAddresses
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (tblAddress == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tblAddress);
        //}

        // GET: Addresses/Create
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

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblAddress tblAddress)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    tblAddress.ID = Guid.NewGuid();
                    _context.Add(tblAddress);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tblAddress);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblAddress = await _context.TblAddresses.FindAsync(id);
                if (tblAddress == null)
                {
                    return NotFound();
                }
                return View(tblAddress);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, TblAddress tblAddress)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblAddress.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tblAddress);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblAddressExists(tblAddress.ID))
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
                return View(tblAddress);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        
        // POST: Addresses/Delete/5
        [HttpPost]

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblAddress = await _context.TblAddresses.FindAsync(id);
                _context.TblAddresses.Remove(tblAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblAddressExists(Guid id)
        {
            return _context.TblAddresses.Any(e => e.ID == id);
        }
    }
}
