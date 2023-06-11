using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Entities;

namespace VisionTake.ViewModels
{
    public class MissionViewModels
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile MyProperty { get; set; }
        public virtual List<TblMission> TblMission { get; set; }
    }
    public class VissionViwModel
    {
        public virtual List<TblVision> TblVision { get; set; }
    }
}
