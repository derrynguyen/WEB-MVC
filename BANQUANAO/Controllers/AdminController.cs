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
            List<Users> Users = db.Users.ToList();
            return View(Users);
        }
        public ActionResult Edit(int id)
        {
            Products pro = db.Products.Where(row => row.idProduct == id).FirstOrDefault();
                        ViewBag.Brand = db.Brands.ToList();

            return View(pro);
        }
        public ActionResult EditUser(int id)
        {
            Users user = db.Users.Where(row => row.ID == id).FirstOrDefault();

            return View(user);
        }
        public ActionResult Delete(int id)
        {
            Products pro = db.Products.Where(row => row.idProduct == id).FirstOrDefault();

            return View(pro);
        }
        public ActionResult DeleteUser(int id)
        {
            Users user = db.Users.Where(row => row.ID == id).FirstOrDefault();

            return View(user);
        }
        public ActionResult Account()
        {
            List<Users> Users = db.Users.ToList();

            return View(Users);
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
       
        public ActionResult DanhSachDon()
        {
            List<Order> order = db.Order.ToList();

            return View(order);
        }
        public ActionResult DetailBill(int ID)
        {
            List<ListProductBill> bill = db.ListProductBill.ToList();
            ViewBag.IDUser = ID;


            return View(bill);
        }
        public ActionResult EditDon(int id)
        {
            Order donHang = db.Order.Where(row => row.OrderID == id).FirstOrDefault();

            return View(donHang);
        }
        public ActionResult XoaDon(int id)
        {

            Order donHang = db.Order.Where(row => row.ID == id).FirstOrDefault();
     

            return View(donHang);
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
            return RedirectToAction("listProducts", "Admin");
        }
        public ActionResult DeleteNguoiDung(int id)
        {
            Users user = db.Users.Where(row => row.ID == id).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Account", "Admin");
        }
        public ActionResult EditUsers(Users user, HttpPostedFileBase Avatar)
        {
            Users profile = db.Users.Where(row => row.ID == user.ID).FirstOrDefault();
            profile.UserName = user.UserName;
            profile.Andreas = user.Andreas;
            profile.FullName = user.FullName;
            profile.Email = user.Email;
            profile.phoneNumber = user.phoneNumber;
            profile.Role = user.Role;

            db.SaveChanges();

            if (Avatar != null && Avatar.ContentLength > 0)
            {
                int id = profile.ID;

                string _FileName = "";
                int index = Avatar.FileName.IndexOf('.');
                _FileName = "avata" + id.ToString() + "." + Avatar.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/Avatar"), _FileName);
                Avatar.SaveAs(_path);

                Users unv = db.Users.FirstOrDefault(x => x.ID == id);
                unv.Avatar = _FileName;
                db.SaveChanges();
            }



            return RedirectToAction("Account", "Admin");
        }
        public ActionResult EditDonHang(Order o)
        {
            Order bill = db.Order.Where(row => row.OrderID == o.OrderID).FirstOrDefault();
            bill.OrderID = o.OrderID;
            bill.CreatedDate = o.CreatedDate;
            bill.StatusPayment = o.StatusPayment;
            bill.StatusShip = o.StatusShip;
            bill.StatusOrder = o.StatusOrder;
            bill.PriceSum = o.PriceSum;


            db.SaveChanges();

            return RedirectToAction("DanhSachDon", "Admin");

        }
        //public ActionResult xoaDonHang(int id)
        //{
        //    ListProductBill bill = db.ListProductBill.Where(row => row.ID == id).FirstOrDefault();
        //    if (bill.ID == id)
        //    {
        //        db.ListProductBill.RemoveRange(db.ListProductBill.Where(row => row.ID == id));
        //    }
        //    Order don = db.Order.Where(row => row.ID == id).FirstOrDefault();

        //    db.Order.Remove(don);
        //    db.SaveChanges();
        //    return RedirectToAction("DanhSachDon", "Admin");
        //}
    }
}