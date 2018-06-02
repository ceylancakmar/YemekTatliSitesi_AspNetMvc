using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CeylaninMutfagi.Areas.Admin.Models
{
    public  class YemekModdel
    {
        public int yemekID { get; set; }
        public string yemekAdi { get; set; }
        public Nullable<int> yKategoriID { get; set; }
        public string malzemeler { get; set; }
        public string yapilisi { get; set; }
        public HttpPostedFileBase Resim{ get; set; }
        public int populerlik { get; set; }

        public virtual yemekKategori yemekKategori { get; set; }
    }
}
