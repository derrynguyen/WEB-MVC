using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BANQUANAO.Models
{
    public class CartItem
    {
        [Key]
        public int idCart { get; set; }
        public string Image { get; set; }
        public int productID { get; set; }
        public string nameProduct { get; set; }

        public int ID { get; set; }
        public virtual Users Users { get; set; }

        public int priceProduct { get; set; }
        public string sizeProduct { get; set; }

        public string colorProduct { get; set; }
        public int Amount { get; set; }

        public int TotalPrice
        {
            get
            {
                return Amount * priceProduct;
            }
        }   

    }
}