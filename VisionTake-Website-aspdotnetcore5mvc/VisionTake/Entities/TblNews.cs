using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblNews
    {
        [Key]
        public Guid ID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
    }
}
