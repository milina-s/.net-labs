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

            // 3
            Console.WriteLine("\n3. Загальна кількість машин кожного бренду, що були взяті у прокат:");

            var q3 = from ch in checks
                     join a in autos on ch.AutoId equals a.Id
                     group ch by a.Brand;

            foreach (var group in q3)
            {
                int sum = 0;
                foreach (var el in group)
                {
                    sum += 1;
                }
                Console.WriteLine($"{group.Key}: {sum} машин");
            }

            // 4
            Console.Write("\n4. Загальна сума прокату всіх машин:");

            var q4 = checks
                .Join(autos,
                ch => ch.AutoId,
                a => a.Id,
                (ch, a) => new
                {
                    term = (ch.EndRent - ch.BeginRent).TotalDays,
                    costPerDay = a.CostPerDay
                }).
                Aggregate(0d, (total, el) => total + el.costPerDay * el.term);

            Console.WriteLine(q4);

            // 5
            Console.WriteLine($"\n5. Середня, найбільша та найменша вартість прокату на день:");

            var q5 = from a in autos
                     select a.CostPerDay;

            Console.WriteLine($"Середня {q5.Average()}\nНайбільша {q5.Max()}\nНайменша {q5.Min()}");

            // 6
            Console.WriteLine($"\n6. Машини з депозитом від 500 до 1000:\n");

            var q6 = autos.
                Where(x => (x.Deposit > 500 && x.Deposit < 1000));

            foreach (var el in q6)
            {
                Console.WriteLine($"{el.Brand} {el.Model} - {el.Deposit}$");
            }

            // 7
            Console.WriteLine("\n7. Машини, що були в аренді у період з 2022.02.10 по 2022.02.20:");

            var q7 = checks
                .Join(autos,
                ch => ch.AutoId,
                a => a.Id,
                (ch, a) => new
                {
                    ch.EndRent,
                    ch.BeginRent,
                    auto = a.Brand + " " + a.Model,
                })
                .Where(res => res.BeginRent <= new DateTime(2022, 02, 10) && res.EndRent >= new DateTime(2022, 02, 20));

            foreach (var el in q7)
                Console.WriteLine(el.auto + ": " + el.BeginRent.ToShortDateString() + "-" +
                    el.EndRent.ToShortDateString());

            // 8
            Console.Write("\n8. Загальна сума депозитів до всіх машин: ");

            var q8 = autos.Sum(el => el.Deposit);
            Console.WriteLine($"{q8}$");

            // 9
            Console.WriteLine("\n9. Додавання та сортування прокату:");

            var newChecks = new List<Check>()
            {
                new Check (7, 5, new DateTime(2022, 1, 10), new DateTime(2022, 1, 30)),
                new Check (2, 1, new DateTime(2022, 4, 2), new DateTime(2022, 4, 15)),
            };

            var q9 = checks.Select(el => el).Concat(newChecks.Select(el => el)).OrderByDescending(el => el.BeginRent);

            foreach (var el in q9)
            {
                Console.WriteLine(el);
            }

            // 10
            Console.Write($"\n10. Чи є хоча б одна машина 2017 року? ");
            bool q10 = autos.
                Any(x => x.Year == 2017);

            Console.WriteLine(q10 ? "Так" : "Ні");

            // 11
            Console.Write($"\n11. Чи всі клієнти ввели номер телефону? ");
            bool q11 = clients.
                All(x => x.Phone != null);

            Console.WriteLine(q11 ? "Так" : "Ні");

            // 12
            Console.WriteLine($"\n12. Нaйбільший депозит за машину: ");
            var q12 = autos.
                OrderBy(x => x.Deposit).
                LastOrDefault();

            Console.WriteLine(q12);
        }

    }

}
