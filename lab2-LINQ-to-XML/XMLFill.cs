using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace lab2
{
    public static class XMLFill
    {
        
        public static void AutoFill()
        {
            List<Client> clients = Data.clients;
            List<Auto> autos = Data.autos;
            List<Check> checks = Data.checks;

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            using (XmlWriter writer = XmlWriter.Create("D:/kpi/net-labs/lab2-LINQ-to-XML/files/autos.xml", settings))
            {
                writer.WriteStartElement("autos");
                foreach (var auto in autos)
                {
                    writer.WriteStartElement("auto");
                    writer.WriteElementString("id", auto.Id.ToString());
                    writer.WriteElementString("brand", auto.Brand);
                    writer.WriteElementString("model", auto.Model);
                    writer.WriteElementString("year", auto.Year.ToString());
                    writer.WriteElementString("costPerDay", auto.CostPerDay.ToString());
                    writer.WriteElementString("deposit", auto.Deposit.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("D:/kpi/net-labs/lab2-LINQ-to-XML/files/clients.xml", settings))
            {
                writer.WriteStartElement("clients");
                foreach (var client in clients)
                {
                    writer.WriteStartElement("client");
                    writer.WriteElementString("id", client.Id.ToString());
                    writer.WriteElementString("name", client.Name);
                    writer.WriteElementString("secondname", client.Secondname);
                    writer.WriteElementString("lastname", client.Lastname);
                    writer.WriteElementString("address", client.Address);
                    writer.WriteElementString("phone", client.Phone);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("D:/kpi/net-labs/lab2-LINQ-to-XML/files/checks.xml", settings))
            {
                writer.WriteStartElement("checks");
                foreach (var check in checks)
                {
                    writer.WriteStartElement("check");
                    writer.WriteElementString("autoId", check.AutoId.ToString());
                    writer.WriteElementString("clientId", check.ClientId.ToString());
                    writer.WriteElementString("beginRent", check.BeginRent.ToString("yyyy.MM.dd"));
                    writer.WriteElementString("endRent", check.EndRent.ToString("yyyy.MM.dd"));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        public static void ManualFill()
        {
            XmlDocument autoDoc = new XmlDocument();
            XmlDeclaration autoDecl = autoDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            autoDoc.AppendChild(autoDecl);
            XmlElement autos = autoDoc.CreateElement("autos");
            autoDoc.AppendChild(autos);
            do
            {
                Console.WriteLine("\tauto");

                Console.Write("id: ");
                string? id = Console.ReadLine();
                Console.Write("brand: ");
                string? brand = Console.ReadLine();
                Console.Write("model: ");
                string? model = Console.ReadLine();
                Console.Write("year: ");
                string? year = Console.ReadLine();
                Console.Write("costPerDay: ");
                string? costPerDay = Console.ReadLine();
                Console.Write("deposit: ");
                string? deposit = Console.ReadLine();

                XmlElement auto = autoDoc.CreateElement("auto");
                XmlElement _id = autoDoc.CreateElement("id");
                XmlElement _brand = autoDoc.CreateElement("brand");
                XmlElement _model = autoDoc.CreateElement("model");
                XmlElement _year = autoDoc.CreateElement("year");
                XmlElement _costPerDay = autoDoc.CreateElement("costPerDay");
                XmlElement _deposit = autoDoc.CreateElement("deposit");

                XmlText IdText = autoDoc.CreateTextNode(id);
                XmlText BrandText = autoDoc.CreateTextNode(brand);
                XmlText ModelText = autoDoc.CreateTextNode(model);
                XmlText YearText = autoDoc.CreateTextNode(year);
                XmlText CostPerDayText = autoDoc.CreateTextNode(costPerDay);
                XmlText DepositText = autoDoc.CreateTextNode(deposit);

                _id.AppendChild(IdText);
                _brand.AppendChild(BrandText);
                _model.AppendChild(ModelText);
                _year.AppendChild(YearText);
                _costPerDay.AppendChild(CostPerDayText);
                _deposit.AppendChild(DepositText);

                autos.AppendChild(auto);
                auto.AppendChild(_id);
                auto.AppendChild(_brand);
                auto.AppendChild(_model);
                auto.AppendChild(_year);
                auto.AppendChild(_costPerDay);
                auto.AppendChild(_deposit);

                Console.WriteLine("Press 'ESC' to stop.\n");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            autoDoc.Save("C:/Users/USer/OneDrive/Рабочий стол/ORPZ/lab2/files/autos.xml");

            XmlDocument clientDoc = new XmlDocument();
            XmlDeclaration clientDecl = clientDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            clientDoc.AppendChild(clientDecl);
            XmlElement clients = clientDoc.CreateElement("clients");
            clientDoc.AppendChild(clients);
            do
            {
                Console.WriteLine("\tclient");

                Console.Write("id: ");
                string? id = Console.ReadLine();
                Console.Write("name: ");
                string? name = Console.ReadLine();
                Console.Write("secondname: ");
                string? secondname = Console.ReadLine();
                Console.Write("lastname: ");
                string? lastname = Console.ReadLine();
                Console.Write("address: ");
                string? address = Console.ReadLine();
                Console.Write("phone: ");
                string? phone = Console.ReadLine();

                XmlElement client = clientDoc.CreateElement("client");
                XmlElement _id = clientDoc.CreateElement("id");
                XmlElement _name = clientDoc.CreateElement("name");
                XmlElement _secondname = clientDoc.CreateElement("secondname");
                XmlElement _lastname = clientDoc.CreateElement("lastname");
                XmlElement _address = clientDoc.CreateElement("address");
                XmlElement _phone = clientDoc.CreateElement("phone");

                XmlText IdText = clientDoc.CreateTextNode(id);
                XmlText NameText = clientDoc.CreateTextNode(name);
                XmlText SecondnameText = clientDoc.CreateTextNode(secondname);
                XmlText LastnameText = clientDoc.CreateTextNode(lastname);
                XmlText AddressText = clientDoc.CreateTextNode(address);
                XmlText PhoneText = clientDoc.CreateTextNode(phone);

                _id.AppendChild(IdText);
                _name.AppendChild(NameText);
                _secondname.AppendChild(SecondnameText);
                _lastname.AppendChild(LastnameText);
                _address.AppendChild(AddressText);
                _phone.AppendChild(PhoneText);

                clients.AppendChild(client);
                client.AppendChild(_id);
                client.AppendChild(_name);
                client.AppendChild(_secondname);
                client.AppendChild(_lastname);
                client.AppendChild(_address);
                client.AppendChild(_phone);

                Console.WriteLine("Press 'ESC' to stop.\n");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            clientDoc.Save("C:/Users/USer/OneDrive/Рабочий стол/ORPZ/lab2/files/clients.xml");

            XmlDocument checkDoc = new XmlDocument();
            XmlDeclaration checkDecl = checkDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            checkDoc.AppendChild(checkDecl);
            XmlElement checks = checkDoc.CreateElement("checks");
            checkDoc.AppendChild(checks);
            do
            {
                Console.WriteLine("\tcheck");

                Console.Write("autoId: ");
                string? autoId = Console.ReadLine();
                Console.Write("clientId: ");
                string? clientId = Console.ReadLine();
                Console.Write("beginRent: ");
                string? beginRent = Console.ReadLine();
                Console.Write("endRent: ");
                string? endRent = Console.ReadLine();

                XmlElement check = checkDoc.CreateElement("check");
                XmlElement _autoId = checkDoc.CreateElement("autoId");
                XmlElement _clientId = checkDoc.CreateElement("clientId");
                XmlElement _beginRent = checkDoc.CreateElement("beginRent");
                XmlElement _endRent = checkDoc.CreateElement("endRent");

                XmlText AutoIdText = checkDoc.CreateTextNode(autoId);
                XmlText ClientIdText = checkDoc.CreateTextNode(clientId);
                XmlText BeginRentText = checkDoc.CreateTextNode(beginRent);
                XmlText EndRentText = checkDoc.CreateTextNode(endRent);

                _autoId.AppendChild(AutoIdText);
                _clientId.AppendChild(ClientIdText);
                _beginRent.AppendChild(BeginRentText);
                _endRent.AppendChild(EndRentText);

                checks.AppendChild(check);
                check.AppendChild(_autoId);
                check.AppendChild(_clientId);
                check.AppendChild(_beginRent);
                check.AppendChild(_endRent);

                Console.WriteLine("Press 'ESC' to stop.\n");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            checkDoc.Save("C:/Users/USer/OneDrive/Рабочий стол/ORPZ/lab2/files/checks.xml");
        }
    }
}
