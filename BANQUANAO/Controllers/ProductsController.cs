using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BANQUANAO.Models;

namespace BANQUANAO.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        /*TYPE :
      1 : ÁO POLO
      2 : ÁO SƠ MI
      3 : ÁO PHÔNG
      4 : ÁO CADIGAN
      5 : ÁO HOODIE
      6 : ÁO JACKET
      7 : TÚI / BACKPACK
      8 : GIÀY
      9 : PHỤ KIỆN
      10 : QUẦN
      */
        // GET: Home
        ConnectDB db = new ConnectDB();
        public ActionResult Index(string SortColumn = "ProductID", int page = 0)
        {
            List<Products> products = db.Products.ToList();
            ViewBag.Brand = db.Brands.ToList();


            ViewBag.SortColumn = SortColumn;
            if (SortColumn == "GiaTang")
            {
                products = products.OrderBy(row => row.priceProduct).ToList();
            }
            if (SortColumn == "GiaGiam")
            {
                products = products.OrderByDescending(row => row.priceProduct).ToList();
            }
            foreach(var brand in ViewBag.Brand)
            {
                if (SortColumn == brand.nameBrand)
                {
                    products = products.Where(row => row.Brand.nameBrand == brand.nameBrand).ToList();
                }
            }
           

            int noOfRecordPerpage = 8;
            int noOfPages = Convert.ToInt32(Math.Ceiling
                (Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerpage)));
            int ChuyenTrang = (page - 1) * noOfRecordPerpage;
            ViewBag.page = page;
            ViewBag.noOfPages = noOfPages;
            products = products.Skip(ChuyenTrang).Take(noOfRecordPerpage).ToList();

            return View(products);
        }

        public ActionResult Detail(int id)
        {
            Products detail = db.Products.Where(row => row.idProduct == id).FirstOrDefault();

            return View(detail);
        }
    }
}