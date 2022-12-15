using BANQUANAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BANQUANAO.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        ConnectDB db = new ConnectDB();
        public ActionResult Index()
        {
            List<Posts> blog = db.Posts.ToList();
            
            blog = blog.OrderBy(row => row.ID).ToList();
            

            return View(blog);
        }
        public bool Insert(Posts entity)
        {
            db.Posts.Add(entity);
            db.SaveChanges();
            return true;
        }
        [HttpPost]
        public ActionResult createPots(Posts p ,HttpPostedFileBase ImgPosts)

        {
            db.Posts.Add(p);
            db.SaveChanges();

            if (ImgPosts != null && ImgPosts.ContentLength > 0)
            {
                int id = int.Parse(db.Posts.ToList().Last().IDPosts.ToString());

                string _FileName = "";
                int index = ImgPosts.FileName.IndexOf('.');
                _FileName = "post" + id.ToString() + "." + ImgPosts.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Content/Blog"), _FileName);
                ImgPosts.SaveAs(_path);

                Posts unv = db.Posts.FirstOrDefault(x => x.IDPosts == id);
                unv.ImgPosts = _FileName;
                db.SaveChanges();
            }
           
            return RedirectToAction("Index");


        }
        public ActionResult updateLike(Posts post ,int id)
        {
            Posts update = db.Posts.Where(row => row.ID == post.ID).FirstOrDefault();
            Posts like = db.Posts.Where(row => row.likePots == post.likePots).FirstOrDefault();
            if(update != null)
            {
                like.likePots += 1;

            }
            db.SaveChanges();
            return RedirectToAction("Index","Blog");

        }
    }
}