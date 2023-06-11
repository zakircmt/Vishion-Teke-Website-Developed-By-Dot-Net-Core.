using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Entities;

namespace VisionTake.ViewModels
{
    public class CreateProductViewModel
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
        public string Description { get; set; }
        public Guid TblCategoryID { get; set; }
        public virtual TblCategory TblCategory { get; set; }
        public virtual TblSubCategory TblSubCategory { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
        public virtual List<TblCategory> Categories { get; set; }
    }
    public class ListingProduct
    {
        public virtual List<TblProduct> RelatedProduct { get; set; }
        public virtual List<TblProduct> Products { get; set; }
    }
}
