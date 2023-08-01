using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using btl.Models;

namespace btl.Areas.Area.Controllers
{
    public class PostsController : Controller
    {
        private DshopEntities db = new DshopEntities();

        // GET: Area/Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.PostCategory);
            return View(posts.ToList());
        }

        // GET: Area/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Area/Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.PostCategories, "ID", "Name");
            return View();
        }

        // POST: Area/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Alias,CategoryID,Image,Description,Content,HomeFlag,HotFlag,ViewCount,CreatedDate,CreatedBy,MetaKeyword,MetaDescription,Status,MoreImages")] Post post, HttpPostedFileBase Image)
        {
            string _FileName = "";
            string _path = "";
            try
            {
                if (Image.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(Image.FileName);
                    _path = Path.Combine(Server.MapPath("~/Uploadimg"), _FileName);
                    Image.SaveAs(_path);
                }
            }
            catch
            {
            }
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.PostCategories, "ID", "Name", post.CategoryID);
            return View(post);
        }

        // GET: Area/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.PostCategories, "ID", "Name", post.CategoryID);
            return View(post);
        }

        // POST: Area/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Alias,CategoryID,Image,Description,Content,HomeFlag,HotFlag,ViewCount,CreatedDate,CreatedBy,MetaKeyword,MetaDescription,Status,MoreImages")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.PostCategories, "ID", "Name", post.CategoryID);
            return View(post);
        }

        // GET: Area/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Area/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
