using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class StateNoMoneyInAtm : State
    {
        public override void Handle(Atm atm)
        {
            Console.WriteLine("There are not enough funds in this ATM.");
            atm.state = new StateProcessing();
        }
    }
}
