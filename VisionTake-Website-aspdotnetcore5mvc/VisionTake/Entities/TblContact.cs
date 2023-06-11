using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblContact
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
