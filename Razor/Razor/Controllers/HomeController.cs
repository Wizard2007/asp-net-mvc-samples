using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product { ProductID = 1, Name = "CPU" 
            , Description = "Intel CPU", Category = "Lenova", Price = 30};
        // GET: Home
        public ActionResult Index()
        {
            return View(myProduct);
        }
        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }
        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplayDiscount = false;
            ViewBag.Supplier = null;
            return View(myProduct);
        }
        public ActionResult DemoArray()
        {
            Product[] products =
                 {
                    new Product { Name = "lenova", Price = 10 },
                    new Product { Name = "mac", Price = 20 },
                    new Product { Name = "lenova", Price = 10 }
            };
            return View(products);
        }
    }
}