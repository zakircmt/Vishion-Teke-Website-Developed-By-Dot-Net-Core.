using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionTake.Entities;

namespace VisionTake.ViewModels
{
    public class MasterLayoutViewModels
    {
        public virtual List<TblSlider> Sliders { get; set; }
        public virtual List<TblAbout> TblAbout { get; set; }
        public virtual List<TblEvent> TblEvent { get; set; }
        public virtual List<TblProduct> TblProduct { get; set; }
        public virtual List<TblReview> TblReview { get; set; }
        public virtual List<TblPatent> TblPatent { get; set; }
        public virtual List<TblPartner> TblPartner { get; set; }


    }
}
