using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    public class Atm
    {
        public State state;
        public Card currentCard;
        public double moneyInAtm;
        

        public Atm(State state, double moneyInAtm)
        {
            this.state = state;
            this.moneyInAtm = moneyInAtm;
            state.Handle(this);
        }

        public void EnterPin(Card card)
        {
            Console.Write("Enter PIN: ");
            int pin = Convert.ToInt32(Console.ReadLine());
            if (pin == card.pin)
            {
                currentCard = card;
            }
            else
            {
                state = new StateInvalidPIN();
                state.Handle(this);
            }
        }

        public void CardBalance()
        {
            Console.WriteLine($"Your current balance is: {currentCard.balance}");
        }
        public void AtmBalance()
        {
            Console.WriteLine($"Available in atm now: {moneyInAtm}");
        }

        public void ToDeposit()
        {
            Console.Write("Enter the amount you want to deposit: ");
            double moneyToDeposit = Convert.ToDouble(Console.ReadLine());
            currentCard.balance += moneyToDeposit;
            moneyInAtm += moneyToDeposit;
            Console.WriteLine("The operation was successful");
        }

        public void ToWithdraw()
        {
            if (moneyInAtm > 0)
            {
                Console.Write("Enter the amount you want to withdraw: ");
                double moneyToWithdraw = Convert.ToDouble(Console.ReadLine());
                if (moneyToWithdraw > moneyInAtm)
                {
                    state = new StateNoMoneyInAtm();
                    state.Handle(this);
                }
                else if (moneyToWithdraw > currentCard.balance)
                {
                    state = new StateNoMoneyOnCard();
                    state.Handle(this);
                }
                else if (moneyToWithdraw > currentCard.limit)
                {
                    state = new StateCardLimit();
                    state.Handle(this);
                }
                else
                {
                    currentCard.balance -= moneyToWithdraw;
                    moneyInAtm -= moneyToWithdraw;
                    Console.WriteLine("The operation was successful");
                }
            }
        }
    }
}
