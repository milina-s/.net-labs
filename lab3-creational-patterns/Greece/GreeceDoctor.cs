using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    internal class GreeceDoctor : AbstractDoctor
    {
        public override void Treat()
        {
            Console.WriteLine("Greece doctor is treating");
        }
    }
}
