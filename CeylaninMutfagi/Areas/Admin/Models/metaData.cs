using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CeylaninMutfagi
{
    public class SliderMetadata
    {
        [Required]
        [Display(Name ="Slider Yazısı")]
        public string SliderText { get; set; }
    }
}
