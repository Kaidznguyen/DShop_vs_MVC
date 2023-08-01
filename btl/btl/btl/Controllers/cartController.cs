using btl.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btl.Controllers
{
    public class cartController : Controller
    {
        DshopEntities db = new DshopEntities();
        // GET: cart
        public ActionResult Index()
        {
            return View((List<OrderDetail>)Session["cart"]);
        }
        public ActionResult AddToCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<OrderDetail> cart = new List<OrderDetail>();
                cart.Add(new OrderDetail { Product = db.Products.Find(id), Quantitty = 1 });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<OrderDetail> cart = (List<OrderDetail>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].Quantitty += 1;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new OrderDetail { Product = db.Products.Find(id), Quantitty = 1 });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        private int isExist(int id)
        {
            List<OrderDetail> cart = (List<OrderDetail>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ID.Equals(id))
                    return i;
            return -1;
        }

        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int Id)
        {
            List<OrderDetail> li = (List<OrderDetail>)Session["cart"];
            li.RemoveAll(x => x.Product.ID == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        public ActionResult Payment(string csName, string csAddress, string csMobile, string csEmail, string payment)
        {
            if(Session["IdUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var order = new Order();
                order.CreatedDate = DateTime.Now;
                order.CreatedBy = csName;
                order.CustomerAddress = csAddress;
                order.CustomerMobile = csMobile;
                order.CustomerEmail = csEmail;
                order.CustomerName = csName;
                order.CustomerMessage = "No Message";
                order.PaymentMethod = payment;
                order.PaymentStatus = "No Message";
                order.Status = true;
                try
                {
                    // Thêm vào bảng Order
                    db.Orders.Add(order);
                    db.SaveChanges();
                    var id = order.ID;
                    var cart = (List<OrderDetail>)Session["cart"];
                    decimal total = 0;
                    foreach (var item in cart)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.ProductID = item.Product.ID;
                        orderDetail.OrderID = id;
                        orderDetail.Quantitty = item.Quantitty;
                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();
                        total += (item.Product.OriginalPrice * item.Product.Quantity);
                    }
                    Session["count"] = null;
                    Session["cart"] = null;
                }
                catch
                {
                    return Redirect("/cart/UnSucces");
                }
                return Redirect("/cart/Succes");
            }         
        }
        public ActionResult Succes(string id)
        {
           var hd = db.Orders.Where(a => a.CustomerId == id).ToList();
            return View(hd);
        }
    }
}