using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
   <option value="1">ÁO SƠ MI</option>
                                <option value="2">ÁO POLO</option>
                                <option value="3">ÁO NỈ</option>
                                <option value="4">QUẦN</option>
                                <option value="5">GIÀY</option>
                                <option value="6">BALO</option>
                                <option value="7">ÁO PHÔNG</option>
                                <option value="8">ÁO LEN</option>
                                <option value="9">ÁO KHOÁC</option>
                                <option value="10">QUẦN SORT</option>
                                <option value="11">TÚI-VÍ</option>
                                <option value="12">VALLI KÉO</option>
                                <option value="13">PHỤ KIỆN</option>
                                <option value="14">VÁY</option>
      */
        // GET: Home
        ConnectDB db = new ConnectDB();
        public ActionResult Index(string search = "", string SortColumn = "ProductID", int page = 0, int TypePro = 0)
        {
            ViewBag.Brand = db.Brands.ToList();
            List<Products> products = db.Products.Where(row =>
              row.nameProduct.Contains(search)).ToList();
            ViewBag.Search = search;

            ViewBag.SortColumn = SortColumn;
            if (SortColumn == "GiaTang")
            {
                products = products.OrderBy(row => row.priceProduct).ToList();
            }
            if (SortColumn == "GiaGiam")
            {
                products = products.OrderByDescending(row => row.priceProduct).ToList();
            }
            if (SortColumn == "AOPOLO")
            {
                TypePro = 2;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "AOSOMI")
            {
                TypePro = 1;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "AONI")
            {
                TypePro = 3;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "QUAN")
            {
                TypePro = 4;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "GIAY")
            {
                TypePro = 5;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "BALO")
            {
                TypePro = 6;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "AOPHONG")
            {
                TypePro = 7;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "AOLEN")
            {
                TypePro = 8;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "AOKHOAC")
            {
                TypePro = 9;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "QUANSHORT")
            {
                TypePro = 10;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "TUIVI")
            {
                TypePro = 11;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "VALIKEO")
            {
                TypePro = 12;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "PHUKIEN")
            {
                TypePro = 13;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            if (SortColumn == "VAY")
            {
                TypePro = 14;
                products = products.Where(row => row.typeProduct == TypePro.ToString()).ToList();
            }
            foreach (var brand in ViewBag.Brand)
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