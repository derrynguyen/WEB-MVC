using BANQUANAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BANQUANAO.APIController
{
    public class ProductsController : ApiController
    {
        ConnectDB DB = new ConnectDB();

        public List<Products> GetProducts()
        {

            List<Products> pro = DB.Products.ToList();
            return pro;
        }
        public Products GetProductRate()
        {
            Products pro = DB.Products.Where(row => row.rateProduct > 4).FirstOrDefault();

            return pro;
        }
    }
}
