using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_simple_language_features.Models
{
    public class Product
    {
        private string name;
        public int ProductID { get; set; }
        public string Name { get { return ProductID.ToString() + name; } set { name = value; } }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}