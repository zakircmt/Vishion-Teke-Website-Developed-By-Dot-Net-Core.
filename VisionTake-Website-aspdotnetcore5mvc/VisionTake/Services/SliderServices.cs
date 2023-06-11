using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Data;
using VisionTake.Entities;

namespace VisionTake.Services
{
    public class SliderServices
    {

        private readonly ApplicationDbContext db;

        public SliderServices(ApplicationDbContext _db)
        {
            db = _db;
        }
        public List<TblSlider> GetFiveSlider()
        {
            var sliderList = db.TblSliders.Take(5).OrderByDescending(x=>x.ID).ToList();
            return sliderList;
        }

        public static implicit operator SliderServices(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}
