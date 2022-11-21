using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BANQUANAO.Models
{
    public class Products
    {
        [Key]
        public int idProduct { get; set; }
        public string nameProduct { get; set; }
        public int priceProduct { get; set; }
        public string colorProduct { get; set; }
        public string materialProduct { get; set; }
        public string AndreasProduct { get; set; }
        public string versionProduct { get; set; }

        public string img1Product { get; set; }
        public string img2Product { get; set; }
        public string img3Product { get; set; }
        public string typeProduct { get; set; }
        public string sexProduct { get; set; }
        public int idBrand { get; set; }
        public int rateProduct { get; set; }

        public int AmountProduct { get; set; }
        public DateTime releaseProduct { get; set; }
        public virtual Brand Brand { get; set; }

    }
}