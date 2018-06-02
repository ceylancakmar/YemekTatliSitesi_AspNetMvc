using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CeylaninMutfagi.Areas.Admin.Models
{
    public class TatliModel
    {
        public int tatliID { get; set; }
        public string tatliAdi { get; set; }
        public string malzemeler { get; set; }
        public string yapilisi { get; set; }
        public Nullable<int> tKategoriID { get; set; }
        public HttpPostedFileBase Resim { get; set; }
        public Nullable<int> populerlik { get; set; }

        public virtual tatliKategori tatliKategori { get; set; }
    }
}