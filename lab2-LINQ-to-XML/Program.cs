using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace lab2
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            bool success = false;
            do
            {
                Console.WriteLine("1 - auto fill\n2 - manual fill\n");

                int operation = 0;
                if (Int32.TryParse(Console.ReadLine(), out operation) && operation >= 1 && operation <= 2)
                {
                    switch (operation)
                    {
                        case 1:
                            XMLFill.AutoFill();
                            success = true;
                            break;

                        case 2:
                            XMLFill.ManualFill();
                            success = true;
                            break;

                        default:
                            Console.WriteLine("Try again\n");
                            break;
                    }

                }
                else
                    Console.WriteLine("Try again\n");

            } while (!success);

            //XMLFill.AutoFill();
            //XMLFill.ManualFill();


            Console.WriteLine("\nautos");
            XDocument autosDoc = XDocument.Load("D:/kpi/net-labs/lab2-LINQ-to-XML/files/autos.xml");
            foreach (XElement auto in autosDoc.Descendants("auto"))
            {
                int? id = (int)auto?.Element("id");
                string brand = (string)auto.Element("brand");
                string model = (string)auto.Element("model");
                string year = (string)auto.Element("year");
                double? costPerDay = (double)auto?.Element("costPerDay");
                double? deposit = (double)auto.Element("deposit");

                Console.WriteLine($"id - {id}, brand - {brand}, model - {model}, " +
                                  $"year - {year}, costPerDay - {costPerDay}, deposit - {deposit}");
            }

            Console.WriteLine("\nclients");
            XDocument clientsDoc = XDocument.Load("D:/kpi/net-labs/lab2-LINQ-to-XML/files/clients.xml");
            foreach (var client in clientsDoc.Descendants("client"))
            {
                int? id = (int)client.Element("id");
                string name = (string)client.Element("name");
                string secondname = (string)client.Element("secondname");
                string lastname = (string)client.Element("lastname");
                string address = (string)client.Element("address");
                string phone = (string)client.Element("phone");

                Console.WriteLine($"id - {id}, name - {name}, secondname - {secondname}, " +
                                  $"lastname - {lastname}, " +
                                  $"address - {address}, phone - {phone}");
            }

            Console.WriteLine("\nchecks");
            XDocument checksDoc = XDocument.Load("D:/kpi/net-labs/lab2-LINQ-to-XML/files/checks.xml");
            foreach (var check in checksDoc.Descendants("check"))
            {
                int? autoId = (int)check.Element("autoId");
                int? clientId = (int)check.Element("clientId");
                string beginRent = (string)check.Element("beginRent");
                string endRent = (string)check.Element("endRent");

                Console.WriteLine($"autoId - {autoId}, clientId - {clientId}, beginRent - {beginRent}, " +
                                  $"endRent - {endRent}");
            }



            // 1
            Console.WriteLine("\n1. Клієнти, що живуть у провулку: ");

            var q1 = clientsDoc.Descendants("client")
                .Where(el => ((string)el.Element("address")).Contains("пров"))
                .Select(el => new
                {
                    name = (string)el.Element("name"),
                    address = (string)el.Element("address")
                });

            foreach (var el in q1)
                Console.WriteLine(el.name + " " + el.address);

            // 2
            Console.WriteLine("\n2. Моделі авто, бренд яких починається на 'H'");

            var q2 = autosDoc.Descendants("auto")
                .Where(el => ((string)el.Element("brand"))[0] == 'H')
                .Select(el => ((string)el.Element("model")));

            foreach (var x in q2)
                Console.WriteLine(x);

            // 3
            Console.Write("\n3. Загальна сумма депозитів до всіх машин: ");

            var q3 = autosDoc.Descendants("auto").Sum(x => (double)x.Element("deposit"));
            Console.WriteLine(q3);

            // 4
            Console.WriteLine("\n4. Ім'я, телефон, к-ть днів та вартість:");

            var q4 = checksDoc.Descendants("check").Select(x => new
            {
                AutoId = (int)x.Element("autoId"),
                ClientId = (int)x.Element("clientId"),
                BeginRent = Convert.ToDateTime((string)x.Element("beginRent")),
                EndRent = Convert.ToDateTime((string)x.Element("endRent"))
            })
                .Join(clientsDoc.Descendants("client")
                .Select(x => new
                {
                    Id = (int)x.Element("id"),
                    Name = (string)x.Element("name"),
                    Phone = (string)x.Element("phone")
                }),
                    ch => ch.ClientId,
                    cl => cl.Id,
                    (ch, cl) => new { ch, cl })
                .Join(autosDoc.Descendants("auto")
                .Select(el => new
                {
                    Id = (int)el.Element("id"),
                    CostPerDay = (double)el.Element("costPerDay"),
                }),
                    ch2 => ch2.ch.AutoId,
                    a => a.Id,
                    (ch3, a) => new { ch3, a }
                ).OrderBy(c => c.a.CostPerDay)
                .Select(res => new
                {
                    name = res.ch3.cl.Name,
                    phone = res.ch3.cl.Phone,
                    term = ((res.ch3.ch.EndRent - res.ch3.ch.BeginRent).TotalDays),
                    cost = res.a.CostPerDay * ((res.ch3.ch.EndRent - res.ch3.ch.BeginRent).TotalDays)
                });

            foreach (var el in q4)
            {
                Console.WriteLine($"{el.name}: {el.phone}; " +
                    $"term: {el.term}; " +
                    $"cost: {el.cost}$");
            }


            // 5
            Console.WriteLine("\n5. Машини, що були в аренді у період з 2022.02.10 по 2022.02.20:");

            var q5 = checksDoc.Descendants("check")
                .Select(el => new
                {
                    autoId = (int)el.Element("autoId"),
                    beginRent = Convert.ToDateTime((string)el.Element("beginRent")),
                    endRent = Convert.ToDateTime((string)el.Element("endRent"))
                })
                .Join(autosDoc.Descendants("auto").Select(el => new
                {
                    id = (int)el.Element("id"),
                    auto = (string)el.Element("brand") + " " + (string)el.Element("model")
                }),
                ch => ch.autoId,
                a => a.id,
                (ch, a) => new { ch, a })
                .Where(res => res.ch.beginRent <= new DateTime(2022, 02, 10) && res.ch.endRent >= new DateTime(2022, 02, 20));

            foreach (var el in q5)
                Console.WriteLine(el.a.auto + " " + el.ch.beginRent.ToShortDateString() + "-" +
                    el.ch.endRent.ToShortDateString());



            // 6
            Console.Write("\n6. Найменша кількість днів на яке будо взято авто: ");

            var q6 = checksDoc.Descendants("check")
                .Min(el => (Convert.ToDateTime((string)el.Element("endRent")) - Convert.ToDateTime((string)el.Element("beginRent"))).TotalDays);

            Console.WriteLine(q6);


            // 7
            Console.WriteLine("\n7. Загальна сума депозиту для кожного бренду: ");

            var q7 = autosDoc.Descendants("auto")
                .Select(x => new
                {
                    Brand = (string)x.Element("brand"),
                    Deposit = (double)x.Element("deposit")
                })
                .GroupBy(res => res.Brand);


            foreach (var group in q7)
            {
                double depositSum = 0;
                foreach (var x in group)
                    depositSum += x.Deposit;
                Console.WriteLine(group.Key + " " + depositSum);
            }


            // 8
            Console.WriteLine("\n8. Клієнти, що брали у прокат машину, що була вибущена після 2020: ");

            var q8 = checksDoc.Descendants("check")
                .Select(el => new
                {
                    AutoId = (int)el.Element("autoId"),
                    ClientId = (int)el.Element("clientId"),
                })
                .Join(clientsDoc.Descendants("client")
                .Select(x => new
                {
                    Id = (int)x.Element("id"),
                    Name = (string)x.Element("name"),
                    Lastname = (string)x.Element("lastname"),
                }),
                    ch => ch.ClientId,
                    cl => cl.Id,
                    (ch, cl) => new { ch, cl })
                .Join(autosDoc.Descendants("auto")
                .Select(el => new
                {
                    Id = (int)el.Element("id"),
                    Year = ((int)el.Element("year")),
                }),
                    ch2 => ch2.ch.AutoId,
                    c => c.Id,
                    (ch3, a) => new { ch3, a }
                ).Where(c => c.a.Year > 2020)
                .Select(res => new { name = res.ch3.cl.Name + " " + res.ch3.cl.Lastname });

            foreach (var el in q8)
                Console.WriteLine(el.name);

            // 9
            Console.WriteLine("\n9. Машини, що були арендовані більше ожного разу: ");

            var q9 = checksDoc.Descendants("check")
                .Select(el => new 
                {
                    AutoId = (int)el.Element("autoId"),
                    ClientId = (int)el.Element("clientId")
                })
                .Join(autosDoc.Descendants("auto")
                .Select(el => new 
                {
                    Id = (int)el.Element("id"),
                    Brand = (string)el.Element("brand"),
                    Model = (string)el.Element("model")
                }),
                ch => ch.AutoId,
                cl => cl.Id,
                (ch2, a) => new { ch2.AutoId, a.Brand, a.Model })
                .GroupBy(res => res.AutoId)
                .Where(res => res.Count() > 1)
                .Select(res => new
                {
                    res.FirstOrDefault().Brand,
                    res.FirstOrDefault().Model
                });

            foreach (var el in q9)
                Console.WriteLine(el.Brand + " " + el.Model);

            // 10
            Console.WriteLine("\n10. Машини, що були випущені післа 2020");

            var q10 = from a in autosDoc.Elements("autos").Elements("auto")
                      where (int)a.Element("year") > 2020
                      select new Auto
                      (
                          (int)a.Element("id"),
                          (string)a.Element("brand"),
                          (string)a.Element("model"),
                          (int)a.Element("year"),
                          (double)a.Element("costPerDay"),
                          (double)a.Element("deposit")
                      );


            foreach (var el in q10)
                Console.WriteLine(el);


            // 11
            Console.WriteLine("\n11. Клієнти що арендували машину з 2022.02.01 по 2022.04.01");

            var q11 = checksDoc.Descendants("check")
                .Select(el => new
                {
                    ClientId = (int)el.Element("clientId"),
                    BeginRent = Convert.ToDateTime((string)el.Element("beginRent"))
                })
                .Join(clientsDoc.Descendants("client")
                .Select(el => new 
                {
                    Id = (int)el.Element("id"),
                    Name = (string)el.Element("name"),
                    Secondname = (string)el.Element("secondname")
                }),
                    ch => ch.ClientId,
                    cl => cl.Id,
                    (ch, cl) => new { ch, cl })
                .Where(el => el.ch.BeginRent > new DateTime(2022, 02, 01)
                        && el.ch.BeginRent < new DateTime(2022, 04, 01))
                .Select(el => new
                {
                    client = el.cl.Name + " " + el.cl.Secondname,
                    date = el.ch.BeginRent.ToShortDateString()
                }); ;

            foreach (var el in q11)
                Console.WriteLine($"{el.client} - {el.date}");

            // 12
            Console.Write("\n12. Вартість прокату всіз машин на день: ");

            var q12 = autosDoc.Descendants("auto").Sum(el => (int)el.Element("costPerDay"));

            Console.WriteLine($"{q12}");

            // 13
            Console.WriteLine("\n13. Усі наявні бренди авто: ");

            var q13 = autosDoc.Descendants("auto")
                .GroupBy(el => ((string)el.Element("brand")))
                .Select(el => el.First());

            foreach (var el in q13)
                Console.WriteLine((string)el.Element("brand"));

            // 14
            Console.WriteLine("\n14. ПІБ усіх зареєстрованих клієнтів: ");

            var q14 = clientsDoc.Descendants("client")
                .Select(el => el);

            foreach (var el in q14)
                Console.WriteLine((string)el.Element("lastname")
                    + " " + (string)el.Element("name")
                    + " " + (string)el.Element("secondname"));


            // 15
            Console.WriteLine("\n15. Машини, аренда яких коштувала від 500 до 1000");

            var q15 = checksDoc.Descendants("check")
                .Select(x => new
                {
                    AutoId = (int)x.Element("autoId"),
                    Term = (Convert.ToDateTime((string)x.Element("endRent")) - Convert.ToDateTime((string)x.Element("beginRent"))).TotalDays
                })
                .Join(autosDoc.Descendants("auto")
                .Select(x => new
                {
                    Id = (int)x.Element("id"),
                    Auto = (string)x.Element("brand") + " " + (string)x.Element("model"),
                    CostPerDay = (double)x.Element("costPerDay")
                }),
                    ch => ch.AutoId,
                    a => a.Id,
                    (ch, a) => new { ch, a })
                .Where(res => res.a.CostPerDay * res.ch.Term > 500 && res.a.CostPerDay * res.ch.Term < 1000)
                .Select(res => res.a.Auto);

            foreach (var el in q15)
                Console.WriteLine($"{el}");

            // 16
            Console.WriteLine("\n16. Машини, відсортовані за роком випуску");

            var q16 = from a in autosDoc.Elements("autos").Elements("auto")
                      orderby (int)a.Element("year") descending
                      select new Auto
                      (
                          (int)a.Element("id"),
                          (string)a.Element("brand"),
                          (string)a.Element("model"),
                          (int)a.Element("year"),
                          (double)a.Element("costPerDay"),
                          (double)a.Element("deposit")
                      );
            foreach (var el in q16)
                Console.WriteLine(el);
            Console.WriteLine();

            // 17
            Console.WriteLine("\n17. Моделі машин, згруповані за брендом:");

            var q17 = from a in autosDoc.Elements("autos").Elements("auto")
                      orderby (string)a.Element("model"), (string)a.Element("brand")
                      group a by (string)a.Element("brand");

            foreach (var group in q17)
            {
                Console.WriteLine($"Бренд: {group.Key}");
                foreach (var el in group)
                {
                    Console.WriteLine($"  {(string)el.Element("model")}");
                }
            }

            // 18
            Console.WriteLine("\n18. Загальна кількість машин кожного бренду, що були взяті у прокат:");

            var q18 = from ch in checksDoc.Elements("checks").Elements("check")
                      join a in autosDoc.Elements("autos").Elements("auto")
                      on ch.Element("autoId")?.Value equals a.Element("id")?.Value
                      group ch by (string)a.Element("brand");

            foreach (var group in q18)
            {
                int sum = 0;
                foreach (var el in group)
                {
                    sum += 1;
                }
                Console.WriteLine($"{group.Key}: {sum} машин");
            }

        }
    }
}
