using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class StateProcessing : State
    {
        public override void Handle(Atm atm)
        {
            Console.WriteLine("Processing...");
        }
    }
}
