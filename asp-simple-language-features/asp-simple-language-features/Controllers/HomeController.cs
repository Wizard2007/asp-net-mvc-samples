using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_simple_language_features.Models;
using System.Text;

namespace asp_simple_language_features.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to url to show an example <br> "
                + "<a href='/Home/AutoProperty'>AutoProperty</a><br> "
                + "<a href='/Home/CreateProduct'>CreateProduct</a><br> "
                + "<a href='/Home/CreateCollection'>CreateCollection</a><br> "
                + "<a href='/Home/UseExtension'>UseExtension</a><br> "
                + "<a href='/Home/UseExtensionEnumerable'>UseExtensionEnumerable</a><br> "
                + "<a href='/Home/UseFilterExtensionMethod'>UseFilterExtensionMethod</a><br> "
                + "<a href='/Home/FindProducts'>LINQ</a><br> "
                ;
        }
        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "CPU";
            return View("Result", (object)String.Format("Product name : {0}", myProduct.Name));
        }
        public ViewResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "CPU",
                Price = 25M,
                Category = "Laptop"
            };
            return View("Result", (object)string.Format("Category : {0}", myProduct.Category));
        }
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30 };
            Dictionary<string, int> myDic = new Dictionary<string, int> { { "apple", 10 }, { "orange", 20 }, { "plum", 30 } };
            return View("Result", (object)stringArray[1]);
        }
        public ViewResult UseExtension()
        {
            decimal cartTotal = 0;
            ShoppingCart shoppingCart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Lenova", Price = 10},
                    new Product { Name = "Mac", Price = 20},
                    new Product { Name = "ThinkPad", Price = 30}
                }
            };
            cartTotal = shoppingCart.TotalPrices();
            return View("Result", (object)string.Format("Total : {0:c}", cartTotal));
        }
        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            { Products = new List<Product>
                {
                    new Product { Name = "Lenova", Price = 10},
                    new Product { Name = "Mac", Price = 20},
                    new Product { Name = "ThinkPad", Price = 30}
                }
            };
            Product[] productArray =
            {
                    new Product { Name = "Lenova", Price = 10},
                    new Product { Name = "Mac", Price = 20},
                    new Product { Name = "ThinkPad", Price = 30}
            };
            decimal cartTotal = products.TotlaPriceEnum();
            decimal arrayTotal = productArray.TotlaPriceEnum();
            return View("Result", (object)string.Format("Cart Total : {0}, Array Total : {1}", cartTotal, arrayTotal));
        }
        public ViewResult UseFilterExtensionMethod()
        {
            decimal total = 0;
            List<Product> Products = new List<Product>
            {
                new Product { Name = "Lenova", Price = 10, Category = "Cat1"},
                new Product { Name = "Mac", Price = 20, Category = "Cat2"},
                new Product { Name = "ThinkPad", Price = 30, Category = "Cat1"},
                new Product { Name = "Lenova1", Price = 10, Category = "Cat2"},
                new Product { Name = "Mac1", Price = 20, Category = "Cat1"},
                new Product { Name = "ThinkPad1", Price = 30, Category = "Cat3"}
            };
            foreach(Product prod in Products.FilterByCategory("Cat1"))
            {
                total += prod.Price;
            }
            decimal total1 = 0;
            Func<Product, bool> categoryFilter = delegate (Product prod) { return prod.Category == "Cat2"; };
            foreach(Product prod in Products.Filter(categoryFilter))
            {
                total1 += prod.Price;
            }
            decimal total2 = 0;
            Func<Product, bool> categoryFilter1 = prod => prod.Category == "Cat3";
            foreach (Product prod in Products.Filter(categoryFilter1))
            {
                total2 += prod.Price;
            }
            decimal total3 = 0;

            foreach (Product prod in Products.Filter(prod => prod.Category == "Cat2" || prod.Price>20))
            {
                total3 += prod.Price;
            }
            return View("Result", (object)string.Format("Total : {0} , Total1 : {1} , Total2 : {2} , Total3 : {3} ", total, total1, total2, total3));
        }
        public ViewResult FindProducts()
        {
            Product [] products =
            {
                new Product { Name = "Lenova", Price = 10, Category = "Cat1"},
                new Product { Name = "Mac", Price = 20, Category = "Cat2"},
                new Product { Name = "ThinkPad", Price = 30, Category = "Cat1"},
                new Product { Name = "Lenova1", Price = 10, Category = "Cat2"},
                new Product { Name = "Mac1", Price = 20, Category = "Cat1"},
                new Product { Name = "ThinkPad1", Price = 30, Category = "Cat3"},
                new Product { Name = "Lenova2", Price = 10, Category = "Cat1"},
                new Product { Name = "Mac2", Price = 20, Category = "Cat2"},
                new Product { Name = "ThinkPad2", Price = 30, Category = "Cat1"},
                new Product { Name = "Lenova3", Price = 10, Category = "Cat2"},
                new Product { Name = "Mac3", Price = 20, Category = "Cat1"},
                new Product { Name = "ThinkPad3", Price = 30, Category = "Cat3"}
            };
            StringBuilder result = new StringBuilder();
            var foundProducts = from match in products orderby match.Price descending select new { match.Name, match.Price};
            int count = 0;
            foreach(var p in foundProducts)
            {
                result.Append(string.Format("Price : {0}, Name: {1} <br> ", p.Price, p.Name));
                if(++count==3){
                    break;
                }
            }
            StringBuilder result1 = new StringBuilder();
            var foundProducts1 = products.OrderByDescending(e=>e.Price).Take(3).Select(e => new { e.Price, e.Name});
            int count1 = 0;
            foreach (var p in foundProducts)
            {
                result1.Append(string.Format("Price : {0}, Name: {1} <br> ", p.Price, p.Name));
                if (++count1 == 3)
                {
                    break;
                }
            }
            return View("Result", (object)string.Format("{0} <br> {1} <br>", result.ToString(), result1.ToString()));
        }
    }
}