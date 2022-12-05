using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BANQUANAO.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ID { get; set; }
        public string StatusPayment { get; set; }
        public string StatusShip { get; set; }
        public string StatusOrder { get; set; }
        public string PriceSum { get; set; }
        public string idHoaDon { get; set; }

        public virtual Users Users { get; set; }
    }
}