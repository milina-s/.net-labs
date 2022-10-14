using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class CashMachineFactory
    {
        Dictionary<string, CashMachine> machines = new Dictionary<string, CashMachine>();
        public CashMachineFactory()
        {
            machines.Add("FirstCashMachine", new FirstCashMachine("FirstCashMachine"));
            machines.Add("SecondCashMachine", new SecondCashMachine("SecondCashMachine"));
        }

        public CashMachine GetCashMachine(string key)
        {
            if (machines.ContainsKey(key))
                return machines[key];
            else
                return null;
        }
    }
}
