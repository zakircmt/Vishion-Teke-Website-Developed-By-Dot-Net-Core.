using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Data;
using VisionTake.Entities;
using VisionTake.ViewModels;

namespace VisionTake.Controllers
{
    public class SharedController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public SharedController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost]
        public IActionResult Index(CreateSliderViewModels model)
        {
            string path = _hostEnvironment.WebRootPath;
            var fileName = Path.GetFileNameWithoutExtension(model.image.FileName);
            var extension = Path.GetExtension(model.image.FileName);
            //model.SliderPicture.TblPicture.PictureURL = fileName = fileName + DateTime.Now.ToString("yyyyymmssfff") + extension;
            var actualPath = Path.Combine(path+"/Images/",fileName);
            using (var fileStream = new FileStream(actualPath, FileMode.Create))
            {
                model.image.CopyTo(fileStream);
            }
            _context.Add(model);
            _context.SaveChanges();

                //if (files != null)
                //{
                //    if (files.Length > 0)
                //    {
                //        //Getting FileName
                //        var fileName = Path.GetFileName(files.FileName);

                //        //Assigning Unique Filename (Guid)
                //        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                //        //Getting file Extension
                //        var fileExtension = Path.GetExtension(fileName);

                //        // concatenating  FileName + FileExtension
                //        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                //        // Combines two strings into a path.
                //        var filepath =
                //new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";

                //        using (FileStream fs = System.IO.File.Create(filepath))
                //        {
                //            files.CopyTo(fs);
                //            fs.Flush();
                //        }
                //    }
                //}
                return View();
        }

        //[HttpPost]
        //public IActionResult UploadPictures(TblSlider tblSlider)
        //{

        //    var uniqueFileName = GetUniqueFileName(model.Image.FileName);
        //    var dir = Path.Combine(_env.ContentRootPath, "Images");
        //    if (!Directory.Exists(dir))
        //    {
        //        Directory.CreateDirectory(dir);
        //    }
        //    var filePath = Path.Combine(dir, uniqueFileName);
        //    await model.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));
        //    return View();

        //    //// JsonResult result = new();
        //    // List<object> picturesJSON = new List<object>();
        //    // var pictures = HttpContext.Request.Form;
        //    // //var picturecount = pictures.ContentLength();
        //    // for (var i = 0; i < pictures.Files.Count(); i++)
        //    // {
        //    //     var picture = pictures;
        //    //     var fileName = Guid.NewGuid();/*+ Path.GetExtension(picture.FileName);*/
        //    //     var path = Path.Combine("~/Content/images/") + fileName;
        //    //     //picture.SaveAs(path);
        //    //     var dbPicture = new TblPicture();
        //    //     dbPicture.PictureURL = (fileName).ToString();
        //    //     //_context.TblPictures.Add(dbPicture);
        //    //     //_context.SaveChanges();
        //    //     var pictureID = SavePicture(dbPicture);
        //    //     picturesJSON.Add(new { ID = pictureID, pictureUrl = fileName });
        //    // }
        //    //result.Data = picturesJSON;
        //    //return result;
        //}
        //private string GetUniqueFileName(string fileName)
        //{
        //    fileName = Path.GetFileName(fileName);
        //    return Path.GetFileNameWithoutExtension(fileName)
        //           + "_"
        //           + Guid.NewGuid().ToString().Substring(0, 4)
        //           + Path.GetExtension(fileName);
        //}

        //public void SavePicture(TblPicture picture)
        //{
        //    _context.TblPictures.Add(picture);
        //    _context.SaveChanges();
        //    //var pictureId =Convert.ToInt32( picture.ID);
        //    //return pictureId;
        //}
    }
}
