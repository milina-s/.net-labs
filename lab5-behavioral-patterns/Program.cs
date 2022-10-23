using System;

namespace lab5
{
    internal class Program
    {
        static void Main()
        {
            Atm atm = new Atm(new StateOpenAtm(), 10000);

            Card card = new Card(6250, 5000, "Samokhatnia Milina", "4441 1144 6302 6433", 1111);

            Menu.AtmMenu(atm, card);
        }
    }
}
