using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    internal class EgyptDoctor : AbstractDoctor
    {
        public override void Treat()
        {
            Console.WriteLine("Egypt doctor is treating");
        }
    }
}
