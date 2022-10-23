using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    public class Card
    {
        public double balance;
        public double limit;
        public string fullName;
        public string cardNumber;
        public int pin;

        public Card(double balance, double limit, string fullName, string cardNumber, int pin)
        {
            this.balance = balance;
            this.limit = limit;
            this.fullName = fullName;
            this.cardNumber = cardNumber;
            this.pin = pin;
        }
    }
}
