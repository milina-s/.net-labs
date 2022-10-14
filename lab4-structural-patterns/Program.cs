using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>()
            {
                new Product("prod0", 29),
                new Product("prod1", 15),
                new Product("prod2", 8),
                new Product("prod3", 26),
                new Product("prod4", 95),
                new Product("prod5", 38),
                new Product("prod6", 17),
                new Product("prod7", 4),
                new Product("prod8", 51),
            };

            string manufacturer1 = "manuf1";
            string manufacturer2 = "manuf2";

            CashMachineFactory cashMachineFactory = new CashMachineFactory();


            CashMachine FirstCashMachine = cashMachineFactory.GetCashMachine("FirstCashMachine");
            FirstCashMachine?.Create(new List<Product>() { products[2], products[3] }, 1, manufacturer1);
            FirstCashMachine?.AddProduct(new List<Product>() { products[7], products[6] });
            FirstCashMachine?.Check();

            Console.WriteLine();

            CashMachine SecondCashMachine = cashMachineFactory.GetCashMachine("SecondCashMachine");
            SecondCashMachine?.Create(new List<Product>() { products[4], products[8], products[3], products[0], products[2] }, 2, manufacturer2);
            //SecondCashMachine?.AddProduct(new List<Product>() { products[8], products[5] });
            SecondCashMachine?.Check();


            Console.Read();
        }
    }
}
