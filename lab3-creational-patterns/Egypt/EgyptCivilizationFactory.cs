using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    internal class EgyptCivilizationFactory : AbstractCivilizationFactory
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

        public EgyptCivilizationFactory()
        {
            Lands = new List<string> { "Egypt lands ", "Forest2 ", "village " };
            Reserve = 3500.0;
        }
    }
}