using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblAddress
    {
        [Key]
        public Guid ID { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
