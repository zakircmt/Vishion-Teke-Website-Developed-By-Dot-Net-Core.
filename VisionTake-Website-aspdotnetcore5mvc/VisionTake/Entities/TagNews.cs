using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TagNews
    {
        [Key]
        public Guid ID { get; set; }
        public Guid TblTagID { get; set; }
        public virtual TblTag TblTag { get; set; }
        public Guid TblNewsID { get; set; }
        public virtual TblNews TblNews { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
    }
}
