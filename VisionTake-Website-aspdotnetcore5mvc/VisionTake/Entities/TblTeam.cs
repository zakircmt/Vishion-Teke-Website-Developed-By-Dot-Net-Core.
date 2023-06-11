using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblTeam
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
    }
}
