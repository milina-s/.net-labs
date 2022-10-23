using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    public abstract class State
    {
        public abstract void Handle(Atm atm);
    }
}
