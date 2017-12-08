using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_simple_language_features.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach(Product prod in cartParam.Products)
            {
                total += prod.Price;
            }
            return total;
        }
        public static decimal TotlaPriceEnum(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach(Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }
        public static IEnumerable<Product>FilterByCategory(this IEnumerable<Product> productEnum, string categoryParam)
        {
            foreach(Product prod in productEnum)
            {
                if(prod.Category== categoryParam)
                {
                    yield return prod;
                }
            }
        }
        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product,bool> selecterParam)
        {
            foreach(Product prod in productEnum)
            {
                if(selecterParam(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}