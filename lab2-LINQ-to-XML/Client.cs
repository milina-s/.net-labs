using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Client(int Id, string Name, string Secondname, string Lastname, string Address, string Phone)
        {
            this.Id = Id;
            this.Name = Name;
            this.Secondname = Secondname;
            this.Lastname = Lastname;
            this.Address = Address;
            this.Phone = Phone;
        }
        public override string ToString()
        {
            return string.Format(
                $"Id: {Id}; " +
                $"fullname: {Lastname} {Name} {Secondname}; " +
                $"addres: {Address};" +
                $"phone: {Phone};");
        }
    }
}
