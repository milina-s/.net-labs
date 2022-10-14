using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4
{
    internal class FirstCashMachine : CashMachine
    {
        public FirstCashMachine(string Type)
        {
            this.Type = Type;
        }
        public override void AddProduct(List<Product> newProducts)
        {
            Products = Products.Concat(newProducts).ToList();
        }

        public override void Create(List<Product> Products, int Id, string Manufacturer)
        {
            this.Products = Products;
            this.Id = Id;
            this.Manufacturer = Manufacturer;
        }

        public override void Check()
        {
            double total = 0;
            foreach (var el in this.Products)
            {
                Console.WriteLine($"  {el.Name}:\t{el.Price,20:c}");
                total += el.Price;
            }

            Console.WriteLine(("").PadRight(40, '-'));
            Console.WriteLine($"  Total:\t{total,20:c}");
            Console.WriteLine($"  Manufacturer: {Manufacturer}");
            Console.WriteLine($"  Id CashMachine: {Id}");
        }

    }
}
