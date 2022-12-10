using BANQUANAO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BANQUANAO.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ConnectDB db = new ConnectDB();
       

        public int MaHang()
        {
            Random r = new Random();
            int maDonHang = r.Next(11111, 99999);
            return maDonHang;
        }
        public ActionResult Index( )
        {
            List<CartItem> cart = db.CartItem.ToList();
            ViewBag.maDonHang = MaHang();


            //List<CartItem> Cart = Session["Cart"] as List<CartItem>;
            return View(cart);
        }
       

        [HttpPost]
        public ActionResult ThemVaoGio( CartItem c , int Amount , ListProductBill bill)
        {
            if (Session["IDUser"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {

                db.ListProductBill.Add(bill);
                db.SaveChanges();
                db.CartItem.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index", "Cart");



            }


        }
        public ActionResult XoaKhoiGio(int idCart )
        {
            CartItem cart = db.CartItem.Where(row => row.idCart == idCart).FirstOrDefault();
            db.CartItem.Remove(cart);

            ListProductBill bill = db.ListProductBill.Where(row => row.idBill == idCart).FirstOrDefault();
            db.ListProductBill.Remove(bill);

            db.SaveChanges();
        
           
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult FixAmount(CartItem c)
        {
            CartItem Cart = db.CartItem.Where(row => row.idCart == c.idCart).FirstOrDefault();
            Cart.Amount = c.Amount;

            db.SaveChanges();
            return RedirectToAction("Index", "Cart");

        }
        public ActionResult DonHang(int page = 0)
        {
          
            List<Order> order = db.Order.ToList();
            //int noOfRecordPerpage = 1;
            //int noOfPages = Convert.ToInt32(Math.Ceiling
            //    (Convert.ToDouble(order.Count) / Convert.ToDouble(noOfRecordPerpage)));
            //int ChuyenTrang = (page - 1) * noOfRecordPerpage;
            //ViewBag.page = page;
            //ViewBag.noOfPages = noOfPages;
            //order = order.Skip(ChuyenTrang).Take(noOfRecordPerpage).ToList();
            return View(order);
        }


        [HttpPost]

        public ActionResult Payment(Order o, int IDUser)
        {
            Order orde = db.Order.Where(row => row.ID == IDUser).FirstOrDefault();

            CartItem cart = db.CartItem.Where(row => row.ID == IDUser).FirstOrDefault();
            if (cart.ID == IDUser)
            {
                db.CartItem.RemoveRange(db.CartItem.Where(row => row.ID == IDUser));
            }

            db.SaveChanges();



            if (orde == null)
            {
                db.Order.Add(o);
                db.SaveChanges();
            }
            else
            {
                db.SaveChanges();
            }

           




            return RedirectToAction("DonHang", "Cart");
        }

        public ActionResult DetailBill(Order l)
        {
            List<ListProductBill> bill = db.ListProductBill.ToList();

          
            return View(bill);

            //return RedirectToAction("DetailBill", "Cart");
        }

    }

}




















//if (Session["Cart"] == null) 
//{
//    Session["Cart"] = new List<CartItem>();  
//}

//List<CartItem> giohang = Session["Cart"] as List<CartItem>; 


//if (giohang.FirstOrDefault(m => m.productID == productID) == null) 
//{
//    Products sp = db.Products.Find(productID); 

//    CartItem newItem = new CartItem()
//    {
//        productID = productID,
//        nameProduct = sp.nameProduct,
//        Amount = 1,
//        Image = sp.img1Product,
//        priceProduct = sp.priceProduct,
//        colorProduct = sp.colorProduct,
//        sizeProduct = sp.sizeProduct,


//    };  

//    giohang.Add(newItem);  
//}
//else
//{
//    CartItem cardItem = giohang.FirstOrDefault(m => m.productID == productID);
//    cardItem.Amount++;
//}













//List<CartItem> giohang = Session["Cart"] as List<CartItem>;
//CartItem itemXoa = giohang.FirstOrDefault(m => m.productID == SanPhamID);
//if (itemXoa != null)
//{
//    giohang.Remove(itemXoa);
//}