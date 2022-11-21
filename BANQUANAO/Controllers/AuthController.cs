using BANQUANAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BANQUANAO.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        ConnectDB db = new ConnectDB();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult profileUser(int id)
        {
            Users profile = db.Users.Where(row => row.ID == id).FirstOrDefault();

            return View(profile);
        }
       
        [HttpPost]
        public ActionResult Register(Users _user)
        {
            if (ModelState.IsValid)
            {       
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                var checkUserName = db.Users.FirstOrDefault(s => s.UserName == _user.UserName);
                var checkUserFullName = db.Users.Where(s => s.FullName == _user.FullName).FirstOrDefault();

                if (check == null && checkUserName == null && checkUserFullName == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Auth");
                }
                if (checkUserName != null)
                {
                    ViewBag.checkTaiKhoan = "Tài khoản này đã tồn tại";

                }
                if(checkUserFullName != null)
                {
                    ViewBag.checkTaiKhoan = "Tên đăng nhập không được để trống!";

                }

                if (check != null)
                {
                    ViewBag.error = "Email này đã tồn tại";
                }


            }
            return View();


        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.UserName.Equals(UserName) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FullName;
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    Session["idUser"] = data.FirstOrDefault().ID;
                    Session["Role"] = data.FirstOrDefault().Role;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult UploadAvatar(Users user, HttpPostedFileBase Avatar)

        {
          

            Users profile = db.Users.Where(row => row.ID == user.ID).FirstOrDefault();
            profile.UserName = user.UserName;
            profile.Andreas = user.Andreas;
            profile.FullName = user.FullName;
            profile.Email = user.Email;
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

            return RedirectToAction("Index","Home");


        }
    }
}