using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblEvent
    {
        [Key]
        public Guid ID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
    }
}
