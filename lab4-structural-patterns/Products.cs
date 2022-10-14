using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
}
