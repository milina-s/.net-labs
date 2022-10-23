using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class Menu
    {
        public static void AtmMenu(Atm atm, Card card)
        {
            bool accountOpened = false;
            while (!accountOpened)
            {
                atm.EnterPin(card);
                if (atm.currentCard != null)
                {
                    accountOpened = true;
                    CardMenu(atm);
                }
            }
        }

        public static void CardMenu(Atm atm)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Card balance");
                Console.WriteLine("4. Atm balance");
                Console.WriteLine("5. Exit");
                Console.Write("Select: ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                   
                    case 1:
                        atm.ToDeposit();
                        break;
                    case 2:
                        atm.ToWithdraw();
                        break;
                    case 3:
                        atm.CardBalance();
                        break;
                    case 4:
                        atm.AtmBalance();
                        break;
                    case 5:
                        exit = true;
                        break;
                }
            }
        }
    }
}
