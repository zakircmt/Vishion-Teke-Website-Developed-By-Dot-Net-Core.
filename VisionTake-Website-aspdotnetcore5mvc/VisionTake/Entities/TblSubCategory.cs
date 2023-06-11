﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisionTake.Entities
{
    public class TblSubCategory
    {
        [Key]
        public Guid ID { get; set; }
        public string SubCategoryName { get; set; }
        public Guid TblCategoryID { get; set; }
        public DateTime? TimeStamp { get; set; }
        public virtual TblCategory TblCategory { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
    }
}
