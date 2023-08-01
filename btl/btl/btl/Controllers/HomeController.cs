using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btl.Models;
using PagedList;
namespace btl.Controllers
{

    public class HomeController : Controller
    {
        DshopEntities db = new DshopEntities();
        // Trang chủ
        public ActionResult Index()
        {

            return View();
        }
        // Tìm kiếm trong trang web
        [HttpGet]
        public ActionResult search(string key, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listsp = db.Products.Where(n => n.Name.Contains(key));
            ViewBag.key = key;
            return View(listsp.OrderBy(n => n.Name).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult searchkey(string key)
        {
            return RedirectToAction("search", new { @key = key });
        }
        // Danh sách bài viết
        public PartialViewResult Menu_post()
        {
            var ds = db.Posts.ToList();
            return PartialView(ds);
        }
        // Danh sách sản phẩm
        public PartialViewResult Menu_item()
        {
            var ds = db.Products.ToList();
            return PartialView(ds);
        }
        public PartialViewResult Menu_item2()
        {
            var ds = db.Products.ToList();
            return PartialView(ds);
        }
        // Danh sách loại sản phẩm
        public PartialViewResult Menu_cateproduct()
        {
            var ds = db.ProductCategories.ToList();
            return PartialView(ds);
        }
        // Danh sách slide
        public PartialViewResult slide()
        {
            var ds = db.Slides.ToList();
            return PartialView(ds);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // Danh sách sản phẩm hot
        public ActionResult Categoryhot(int? page)
        {
            if (page == null) page = 1;
            var ds = db.Products.Where(s => s.HotFlag == true).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        // Trang chi tiết sản phẩm
        public ActionResult DetailProduct(int id)
        {
            var ds = db.Products.FirstOrDefault(s => s.ID == id);
            return View(ds);
        }
        // Trang xem sản phẩm theo loại
        public ActionResult listProduct(int id, int? page)
        {
            if (page == null) page = 1;
            var ds = db.Products.Where(s => s.CategoryID == id).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        // Danh sách loại bài viết
        public ActionResult CategoryPost()
        {
            var ds = db.Posts.Where(s => s.HomeFlag == true && s.Status == true).ToList();
            return View(ds);
        }
        // Trang chi tiết bài viết
        public ActionResult DetailPost(int id)
        {
            var ds = db.Posts.FirstOrDefault(s => s.ID == id);
            return View(ds);
        }
        // Trang đăng ký
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Register(ApplicationUser user)
        //{
        //    return View("Index");
        //}
        // Trang đăng nhập
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Loginss(login lg)
        {
            var kq = true;

            if (ModelState.IsValid)
            {
                using (DshopEntities ue = new DshopEntities())
                {
                    var log = ue.ApplicationUsers.Where(a => a.UserName.Equals(lg.username) && a.PasswordHash.Equals(lg.password)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["FullName"] = log.FullName;
                        Session["Email"] = log.Email;
                        Session["IdUser"] = log.Id;
                        Session["UserName"] = log.UserName;
                        Session["Access"] = log.LockoutEnabled;
                        //return RedirectToAction("Index", "Area/products");
                        kq = true;
                    }
                    else
                    {
                        kq = false;
                        //Response.Write("<script> alert('Tên tài khoản hoặc mật khẩu không hợp lệ') </script>");
                    }
                }
            }
            //return View();
            return Json(kq, JsonRequestBehavior.AllowGet);

        }
        // Chức năng đăng xuất
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }   

}