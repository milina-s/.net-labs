using System;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Civilization greeceCivilization = new Civilization(new GreeceCivilizationFactory());
            greeceCivilization.MakeLaborerWork();
            greeceCivilization.MakeWarriorFight();
            greeceCivilization.MakeDoctorTreat();
            greeceCivilization.ShowLandsAndReserve();

            Civilization egyptCivilization = new Civilization(new EgyptCivilizationFactory());
            egyptCivilization.MakeLaborerWork();
            egyptCivilization.MakeWarriorFight();
            egyptCivilization.MakeDoctorTreat();
            egyptCivilization.ShowLandsAndReserve();
        }
    }
}
