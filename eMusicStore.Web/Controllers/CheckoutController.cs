using eMusicStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMusicStore.Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        MusicStoreEntities _storeDB = new MusicStoreEntities();
        const string PromoCode = "FREE";

        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection form)
        {
            var order = new Order();
            TryUpdateModel(order);
            try
            {
                if (!string.Equals(form["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase))
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    _storeDB.Orders.Add(order);
                    _storeDB.SaveChanges();
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch
            {
                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            bool isValid = _storeDB.Orders.Any(o => o.OrderId == id && o.Username == User.Identity.Name);
            if (isValid)
            {
                ViewBag.OrderId = id;
                return View();
            }
            else
            {
                return View("Error");
            }
        }
    }
}