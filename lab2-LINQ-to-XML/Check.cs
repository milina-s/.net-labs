using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public class Check
    {
        public int AutoId { get; set; }
        public int ClientId { get; set; }

        public DateTime EndRent { get; set; }

        public DateTime BeginRent { get; set; }

        public Check(int AutoId, int ClientId, DateTime BeginRent, DateTime EndRent)
        {
            this.AutoId = AutoId;
            this.ClientId = ClientId;
            this.EndRent = EndRent;
            this.BeginRent = BeginRent;
        }

        public override string ToString()
        {
            return string.Format(
                $"ClientId: {ClientId}; " +
                $"autoId: {AutoId}; " +
                $"rent: {BeginRent.ToShortDateString()} - {EndRent.ToShortDateString()}");
        }
    }


}
