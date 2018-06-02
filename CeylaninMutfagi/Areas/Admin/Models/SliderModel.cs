using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CeylaninMutfagi.Areas.Admin.Models
{
  public  class SliderModel
    {
        public int ID { get; set; }
   
        public string SliderText { get; set; }
        public Nullable<System.DateTime> BaslangicTarihi { get; set; }
        public Nullable<System.DateTime> BitisTarihi { get; set; }
        public HttpPostedFileBase Resim { get; set; }
    }
}
