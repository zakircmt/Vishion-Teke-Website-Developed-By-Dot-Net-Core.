﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblTag
    {
        [Key]
        public Guid ID { get; set; }
        public string TagName { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
