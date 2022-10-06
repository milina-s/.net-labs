using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    internal class GreeceCivilizationFactory : AbstractCivilizationFactory
    {
        public override AbstractDoctor CreateDoctor()
        {
            return new EgyptDoctor();
        }
        public override AbstractLaborer CreateLaborer()
        {
            return new EgyptLaborer();
        }
        public override AbstractWarrior CreateWarrior()
        {
            return new EgyptWarrior();
        }

        public GreeceCivilizationFactory()
        {
            Lands = new List<string> { "Greece lands ", "Forest ", "Church " };
            Reserve = 5000.0;
        }
    }
}