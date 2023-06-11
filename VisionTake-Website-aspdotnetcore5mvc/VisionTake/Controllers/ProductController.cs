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
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public ProductController(ApplicationDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var applicationDbContext = _context.TblProducts.Include(t => t.TblCategory);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public IActionResult Products()
        {
            ListingProduct model = new ListingProduct();
            model.Products = _context.TblProducts.OrderByDescending(x => x.ID).ToList(); ;
           
            return View(model);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblProduct = await _context.TblProducts
                    .Include(t => t.TblCategory)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (tblProduct == null)
                {
                    return NotFound();
                }

                return View(tblProduct);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public IActionResult Detail(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.product = _context.TblProducts.Take(20).OrderByDescending(x => x.ID).ToList();

            var tblProduct = _context.TblProducts
                .Include(t => t.TblCategory)
                .FirstOrDefault(m => m.ID == id);



            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);

        }

        // GET: Product/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                CreateProductViewModel model = new CreateProductViewModel();
                //ViewBag.Category = new SelectList(_context.TblCategories, "ID", "CategoryName");
                model.Categories = _context.TblCategories.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (ModelState.IsValid)
                {
                    model.ID = Guid.NewGuid();
                    TblProduct product = new TblProduct();

                    product.ID = model.ID;
                    product.ProductName = model.ProductName;
                    product.ProductModel = model.ProductModel;
                    product.ImageUrl = model.ImageUrl;
                    product.MyProperty = model.MyProperty;
                    product.TblCategoryID = model.TblCategoryID;
                    product.Description = model.Description;



                    var uniqueFileName = UploadedFile(model);
                    product.ImageUrl = uniqueFileName;
                    _context.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                //ViewData["TblCategoryID"] = new SelectList(_context.TblCategories, "ID", "ID", tblProduct.TblCategoryID);
                return View(model);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }
        public string UploadedFile(CreateProductViewModel slider)
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
        public string UploadedFiles(TblProduct slider)
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

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tblProduct = await _context.TblProducts.FindAsync(id);
                CreateProductViewModel model = new CreateProductViewModel();
                //ViewBag.Category = new SelectList(_context.TblCategories, "ID", "CategoryName");

                model.ID = tblProduct.ID;
                model.ProductName = tblProduct.ProductName;
                model.ProductModel = tblProduct.ProductModel;
                model.Description = tblProduct.Description;
                model.ImageUrl = tblProduct.ImageUrl;
                model.TblCategoryID = tblProduct.TblCategoryID;
                model.Categories = _context.TblCategories.ToList();
                if (tblProduct == null)
                {
                    return NotFound();
                }
               // ViewData["TblCategoryID"] = new SelectList(_context.TblCategories, "ID", "ID", tblProduct.TblCategoryID);
                return View(model);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TblProduct tblProduct)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                if (id != tblProduct.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if ((tblProduct.ImageUrl == null && tblProduct.MyProperty != null) || (tblProduct.ImageUrl != null && tblProduct.MyProperty != null))
                        {
                            var uniqueFileName = UploadedFiles(tblProduct);
                            tblProduct.ImageUrl = uniqueFileName;
                            _context.Update(tblProduct);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.Update(tblProduct);
                            await _context.SaveChangesAsync();
                        }

                        _context.Update(tblProduct);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TblProductExists(tblProduct.ID))
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
                ViewData["TblCategoryID"] = new SelectList(_context.TblCategories, "ID", "ID", tblProduct.TblCategoryID);
                return View(tblProduct);
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        // GET: Product/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (HttpContext.Session.GetString("FirstName") != null)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var tblProduct = await _context.TblProducts
        //            .Include(t => t.TblCategory)
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (tblProduct == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tblProduct);
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Auth");
        //    }
        //}

        // POST: Product/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (HttpContext.Session.GetString("FirstName") != null)
            {
                var tblProduct = await _context.TblProducts.FindAsync(id);
                _context.TblProducts.Remove(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("login", "Auth");
            }
        }

        private bool TblProductExists(Guid id)
        {
            return _context.TblProducts.Any(e => e.ID == id);
        }
    }
}
