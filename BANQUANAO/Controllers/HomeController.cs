using BANQUANAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BANQUANAO.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Index(int page = 0)
        {

            List<Products> products = db.Products.ToList();
            products = products.Where(row => row.rateProduct > 4).ToList();
            //Products products = db.Products.Where(row => row.releaseProduct. > 4).FirstOrDefault();


            int noOfRecordPerpage = 4;
            int noOfPages = Convert.ToInt32(Math.Ceiling
                (Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerpage)));
            int ChuyenTrang = (page - 1) * noOfRecordPerpage;
            ViewBag.page = page;
            ViewBag.noOfPages = noOfPages;
            products = products.Skip(ChuyenTrang).Take(noOfRecordPerpage).ToList();
            return View(products);
        }
        public ActionResult error404()
        {
            return View();
        }
    }
}