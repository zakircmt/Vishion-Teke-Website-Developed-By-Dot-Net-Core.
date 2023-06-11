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
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public AuthController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: TblUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblUsers.ToListAsync());
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string usermail, string password)
        {
            var findUser = _context.TblUsers.Where(x => x.Email == usermail && x.Password == password).FirstOrDefault();
            if (findUser != null)
            {
                HttpContext.Session.SetString("FirstName", findUser.FirstName);
                return RedirectToAction("Index","AdminDashboard");
            }
            else {
                ViewBag.message = "Your username or password is not valid!";
                return View("login");
            }
        }
        // GET: TblUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // GET: TblUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                tblUser.ID = Guid.NewGuid();
                var uniqueFileName = UploadedFile(tblUser);
                tblUser.ImageUrl = uniqueFileName;
                _context.Add(tblUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUser);
        }

        public string UploadedFile(TblUser slider)
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

        // GET: TblUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers.FindAsync(id);
            if (tblUser == null)
            {
                return NotFound();
            }
            return View(tblUser);
        }

        // POST: TblUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TblUser tblUser)
        {
            if (id != tblUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (tblUser.ImageUrl == null)
                    {
                        var uniqueFileName = UploadedFile(tblUser);
                        tblUser.ImageUrl = uniqueFileName;
                        _context.Update(tblUser);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Update(tblUser);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserExists(tblUser.ID))
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
            return View(tblUser);
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("FirstName");
            return RedirectToAction("login");
        }

        private bool TblUserExists(Guid id)
        {
            return _context.TblUsers.Any(e => e.ID == id);
        }
    }
}
