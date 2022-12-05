using BANQUANAO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace BANQUANAO.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ConnectDB db = new ConnectDB();

        public ActionResult Index( )
        {
            List<CartItem> cart = db.CartItem.ToList();
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
        public RedirectToRouteResult XoaKhoiGio(int idCart )
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
            CartItem cart = db.CartItem.Where(row => row.ID == IDUser).FirstOrDefault();
            if (cart.ID == IDUser)
            {
                db.CartItem.RemoveRange(db.CartItem.Where(row => row.ID == IDUser));
                db.SaveChanges();

            }

            db.Order.Add(o);
            db.SaveChanges();



            List<Order> order = db.Order.ToList();

            return RedirectToAction("DonHang", "Cart");
        }

        public ActionResult DetailBill()
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