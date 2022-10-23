using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    public class StateInvalidPIN : State
    {
        public override void Handle(Atm atm)
        {
            Console.WriteLine("You've entered invalid PIN. Please try again.");
            atm.state = new StateProcessing();
        }
    }
}
