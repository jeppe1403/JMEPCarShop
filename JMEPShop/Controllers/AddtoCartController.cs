using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JMEPShop.Models;

namespace JMEPShop.Controllers
{
    public class AddtoCartController : Controller
    {
        // GET: AddtoCart
        public ActionResult Add(Car cr)
        {
            if (Session["cart"] == null)
            {
                List<Car> li = new List<Car>();
                li.Add(cr);
                Session["cart"] = li;
                ViewBag.cart = li.Count();

                Session["count"] = 1;
            }
            else
            {
                List<Car> li = (List<Car>)Session["cart"];
                li.Add(cr);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Myorder", "AddToCart");
        }

        public ActionResult Myorder()
        {

            return View((List<Car>)Session["cart"]);

        }

        public ActionResult Remove(Car cr)
        {
            List<Car> li = (List<Car>)Session["cart"];
            li.RemoveAll(x => x.ID == cr.ID);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
        }
    }
}