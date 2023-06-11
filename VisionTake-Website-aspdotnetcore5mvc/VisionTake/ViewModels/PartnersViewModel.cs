using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Entities;

namespace VisionTake.ViewModels
{
    public class CreatePartnersViewModel
    {
        public virtual List<TblPartnerCategory> PartnerCategories { get; set; }
        [Key]
        public Guid ID { get; set; }
        public string CompanyName { get; set; }
        public DateTime? TimeStamp { get; set; }
        public Guid? TblPartnerCategoryID { get; set; }
        public virtual TblPartnerCategory TblPartnerCategory { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
    }
}
