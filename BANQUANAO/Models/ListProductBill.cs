using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BANQUANAO.Models
{
    public class ListProductBill
    {
        [Key]
        public int idBill { get; set; }
        public string Image { get; set; }
        public int productID { get; set; }
        public string nameProduct { get; set; }

        public int ID { get; set; }
        public virtual Users Users { get; set; }

        public string idHoaDon { get; set; }

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