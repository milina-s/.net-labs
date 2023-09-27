using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public class Auto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double CostPerDay { get; set; }
        public double Deposit { get; set; }

        public Auto(int Id, string Brand, string Model, int Year, double CostPerDay, double Deposit)
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.CostPerDay = CostPerDay;
            this.Deposit = Deposit;
        }

        public override string ToString()
        {
            return string.Format(
                $"Id: {Id}; " +
                $"model: {Brand} {Model}; " +
                $"year: {Year}; " +
                $"costPerDay: {CostPerDay}; " +
                $"deposit: {Deposit}");
        }
    }

}
