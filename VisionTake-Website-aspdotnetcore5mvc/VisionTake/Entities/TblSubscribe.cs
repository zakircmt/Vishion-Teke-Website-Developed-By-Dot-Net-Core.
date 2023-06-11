using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblSubscribe
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string EmailAddress { get; set; }
    }
}
