using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BANQUANAO.Models
{
  
    public class Brand
    {
        [Key]
        public int idBrand { get; set; }
        public string nameBrand { get; set; }
        public string storyBrand { get; set; }

    }
}