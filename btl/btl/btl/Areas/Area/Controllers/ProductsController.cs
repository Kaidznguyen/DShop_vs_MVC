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
    public class ProductsController : Controller
    {
        private DshopEntities db = new DshopEntities();

        // GET: Area/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductCategory);
            return View(products.ToList());
        }

        // GET: Area/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Area/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name");
            return View();
        }

        // POST: Area/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Alias,CategoryID,Image,MoreImages,Price,PromotionPrice,Description,Content,HomeFlag,HotFlag,ViewCount,CreatedDate,CreatedBy,MetaKeyword,MetaDescription,Status,Warranty,Tags,Quantity,OriginalPrice")] Product product, HttpPostedFileBase Image)
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
                product.Image = _FileName;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Area/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Area/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Name,Alias,CategoryID,Image,MoreImages,Price,PromotionPrice,Description,Content,HomeFlag,HotFlag,ViewCount,CreatedDate,CreatedBy,MetaKeyword,MetaDescription,Status,Warranty,Tags,Quantity,OriginalPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Area/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Area/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
