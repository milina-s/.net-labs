using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    abstract class AbstractCivilizationFactory
    {
        public List<String> Lands;
        public double Reserve;
        public abstract AbstractDoctor CreateDoctor();
        public abstract AbstractLaborer CreateLaborer();
        public abstract AbstractWarrior CreateWarrior();
    }
}
