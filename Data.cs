using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public static class Data
    {
        public static List<Auto> autos = new List<Auto>()
        {
            new Auto(1, "Hyundai", "Accent", 2019, 34, 500),
            new Auto(2, "Hyundai", "Tucson", 2021, 77, 1000),
            new Auto(3, "Hyundai", "Elantra", 2021, 46, 600),
            new Auto(4, "Honda", "Accord X", 2019, 63, 800),
            new Auto(5, "Honda", "CRV", 2018, 63, 800),
            new Auto(6, "Toyota", "Corolla", 2021, 42, 600),
            new Auto(7, "Toyota", "Prado", 2021, 119, 1500),
        };

        public static List<Client> clients = new List<Client>()
        {
            new Client(1, "Іван", "Іванович", "Іваненко", "Київ, пров. Волкова, 64", "066-842-98-76"),
            new Client(2, "Анна", "Ігорівна", "Шевченко", "Вінниця, вул. Леніна, 71", "050-066-99-14"),
            new Client(3, "Антон", "Андрійович", "Кравченко", "Дніпро, вулю Шевченка, 21", "050-205-78-31"),
            new Client(4, "Тетяна", "Тарасовна", "Крамарчук", "Київ, пров. Лесі Українки, 10", "099-967-51-71"),
            new Client(5, "Павло", "Петрович", "Захарчук", "Київ, пров. Гагаріна, 40", "050-796-25-34"),
        };

        public static List<Check> checks = new List<Check>()
        {
            new Check(5, 1, new DateTime(2022, 01, 12), new DateTime(2022, 02, 28)),
            new Check(6, 2, new DateTime(2022, 02, 01), new DateTime(2022, 03, 15)),
            new Check(1, 3, new DateTime(2022, 03, 05), new DateTime(2022, 03, 10)),
            new Check(3, 4, new DateTime(2022, 03, 10), new DateTime(2022, 03, 13)),
            new Check(7, 3, new DateTime(2022, 01, 02), new DateTime(2022, 01, 08)),
            new Check(1, 5, new DateTime(2022, 04, 03), new DateTime(2022, 04, 20)),
            new Check(2, 5, new DateTime(2022, 02, 25), new DateTime(2022, 03, 15)),
            new Check(4, 4, new DateTime(2022, 01, 09), new DateTime(2022, 01, 30)),
            new Check(5, 3, new DateTime(2022, 02, 09), new DateTime(2022, 02, 12)),
        };
    }
}
