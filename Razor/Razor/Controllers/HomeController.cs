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
    }
}