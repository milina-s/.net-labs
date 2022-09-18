using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Auto> autos = Data.autos;
            List<Client> clients = Data.clients;
            List<Check> checks = Data.checks;

            // 1
            Console.WriteLine("\n1. Список клієнтів та машин, що вони брали на прокат: ");

            var q1 = from ch in checks
                     join a in autos on ch.AutoId equals a.Id
                     join cl in clients on ch.ClientId equals cl.Id
                     group a by cl;


            foreach (var group in q1)
            {
                Console.WriteLine($"{group.Key.Name} {group.Key.Lastname}: ");
                foreach (var el in group)
                {
                    Console.WriteLine($"   {el}");
                }
            }

            // 2
            Console.WriteLine("\n2. Моделі машин, згруповані за брендом:");

            var q2 = from a in autos
                     orderby a.Model, a.Brand
                     group a by a.Brand;

            foreach (var group in q2)
            {
                Console.WriteLine($"\nБренд: {group.Key}");
                foreach (var el in group)
                {
                    Console.WriteLine($"  {el.Model}");
                }
            }


        }

    }

}
