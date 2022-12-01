using BANQUANAO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BANQUANAO.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ConnectDB db = new ConnectDB();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Products pro = db.Products.Where(row => row.idProduct == id).FirstOrDefault();
                        ViewBag.Brand = db.Brands.ToList();

            return View(pro);
        }
        public ActionResult Delete(int id)
        {
            Products pro = db.Products.Where(row => row.idProduct == id).FirstOrDefault();

            return View(pro);
        }
        public ActionResult listProducts(int page = 0)
        {
            ViewBag.Brand = db.Brands.ToList();

            List<Products> products = db.Products.ToList();

            ///Phân trang
            ///
            int noOfRecordPerpage = 8;
            int noOfPages = Convert.ToInt32(Math.Ceiling
                (Convert.ToDouble(products.Count) / Convert.ToDouble(noOfRecordPerpage)));
            int ChuyenTrang = (page - 1) * noOfRecordPerpage;
            ViewBag.page = page;
            ViewBag.noOfPages = noOfPages;
            products = products.Skip(ChuyenTrang).Take(noOfRecordPerpage).ToList();    
            return View(products);
        }
       
        [HttpPost]
        public ActionResult AddProduct(Products p, HttpPostedFileBase img1Product, HttpPostedFileBase img2Product, HttpPostedFileBase img3Product)

        {
            db.Products.Add(p);

            db.SaveChanges();

            if (img1Product != null && img1Product.ContentLength > 0)
            {
                int id = int.Parse(db.Products.ToList().Last().idProduct.ToString());

                string _FileName = "";
                int index = img1Product.FileName.IndexOf('.');
                _FileName = "item1" + id.ToString() + "." + img1Product.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/Images/Product"), _FileName);
                img1Product.SaveAs(_path);

                Products unv = db.Products.FirstOrDefault(x => x.idProduct == id);
                unv.img1Product = _FileName;
                db.SaveChanges();
            }

            if (img2Product != null && img2Product.ContentLength > 0)
            {
                int id = int.Parse(db.Products.ToList().Last().idProduct.ToString());

                string _FileName = "";
                int index = img2Product.FileName.IndexOf('.');
                _FileName = "item2" + id.ToString() + "." + img2Product.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/Images/Product"), _FileName);
                img2Product.SaveAs(_path);

                Products unv = db.Products.FirstOrDefault(x => x.idProduct == id);
                unv.img2Product = _FileName;
                db.SaveChanges();
            }
            if (img3Product != null && img3Product.ContentLength > 0)
            {
                int id = int.Parse(db.Products.ToList().Last().idProduct.ToString());

                string _FileName = "";
                int index = img3Product.FileName.IndexOf('.');
                _FileName = "item3" + id.ToString() + "." + img3Product.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/Images/Product"), _FileName);
                img3Product.SaveAs(_path);

                Products unv = db.Products.FirstOrDefault(x => x.idProduct == id);
                unv.img3Product = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult DeleteProducts(int id)
        {
            Products pro = db.Products.Where(row => row.idProduct == id).FirstOrDefault();
            db.Products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("listProducts", "Admin");
        }
        public ActionResult EditProduct(Products pro, HttpPostedFileBase img1Product)
        {
            Products pronew = db.Products.Where(row => row.idProduct == pro.idProduct).FirstOrDefault();
            pronew.nameProduct = pro.nameProduct;
            pronew.priceProduct = pro.priceProduct;
            pronew.colorProduct = pro.colorProduct;
            pronew.materialProduct = pro.materialProduct;
            pronew.AndreasProduct = pro.AndreasProduct;
            pronew.versionProduct = pro.versionProduct;
           
            pronew.typeProduct = pro.typeProduct;
            pronew.sexProduct = pro.sexProduct;
            pronew.idBrand = pro.idBrand;
            pronew.rateProduct = pro.rateProduct;
            pronew.AmountProduct = pro.AmountProduct;
            pronew.releaseProduct = pro.releaseProduct;

            if (img1Product != null && img1Product.ContentLength > 0)
            {
                int id = int.Parse(db.Products.ToList().Last().idProduct.ToString());

                string _FileName = "";
                int index = img1Product.FileName.IndexOf('.');
                _FileName = "item1" + id.ToString() + "." + img1Product.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/Images/Product"), _FileName);
                img1Product.SaveAs(_path);

                Products unv = db.Products.FirstOrDefault(x => x.idProduct == id);
                unv.img1Product = _FileName;
                db.SaveChanges();
            }
            db.SaveChanges();
            return RedirectToAction("listProducts", "Admin");
        }
    }
}