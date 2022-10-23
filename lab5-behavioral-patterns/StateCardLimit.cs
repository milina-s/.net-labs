using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class StateCardLimit : State
    {
        public override void Handle(Atm atm)
        {
            Console.WriteLine("This amount exceeds the limit on the card.");
            atm.state = new StateProcessing();
        }
    }
}
