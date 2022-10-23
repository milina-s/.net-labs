using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class StateOpenAtm : State
    {
        public override void Handle(Atm atm)
        {
            Console.WriteLine("Atm is opened\n");
            atm.state = new StateProcessing();
        }
    }
}
