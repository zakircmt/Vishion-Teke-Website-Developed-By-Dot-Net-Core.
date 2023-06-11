using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Entities;

namespace VisionTake.ViewModels
{
    public class CreateSliderViewModels
    {
        public string SliderTitle { get; set; }
        public string SliderDescription { get; set; }
        public string SliderPictures { get; set; }
        public IFormFile image { get; set; }
    }
}
