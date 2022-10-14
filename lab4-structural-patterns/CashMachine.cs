using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    abstract class CashMachine
    {
        protected int Id;
        protected string Manufacturer;
        protected string Type;
        protected List<Product> Products;

        public abstract void Create(List<Product> Products, int Id, string Manufacturer);
        public abstract void AddProduct(List<Product> newProducts);
        public abstract void Check();
    }
    
}
