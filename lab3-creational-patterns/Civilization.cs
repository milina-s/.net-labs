using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    internal class Civilization
    {
        private AbstractDoctor doctor;
        private AbstractLaborer laborer;
        private AbstractWarrior warrior;
        private List<String> lands;
        private double reserve;

        public Civilization(AbstractCivilizationFactory factory)
        {
            doctor = factory.CreateDoctor();
            laborer = factory.CreateLaborer();
            warrior = factory.CreateWarrior();
            lands = factory.Lands;
            reserve = factory.Reserve;
        }

        public void MakeDoctorTreat()
        {
            doctor.Treat();
        }

        public void MakeLaborerWork()
        {
            laborer.Work();
        }

        public void MakeWarriorFight()
        {
            warrior.Fight();
        }

        public void ShowLandsAndReserve()
        {
            Console.Write("Lands: ");
            foreach (String land in lands)
            {
                Console.Write(land );
            }
            Console.WriteLine($"\nReserve: {reserve.ToString()}");
        }
    }
}
