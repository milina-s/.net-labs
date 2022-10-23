using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class StateNoMoneyOnCard : State
    {
        public override void Handle(Atm atm)
        {
            Console.WriteLine("There are not enough funds on your card");
            atm.state = new StateProcessing();
        }
    }
}
