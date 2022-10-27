using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(300, 50);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(600, 200);
            FamilyCar familyCar = new FamilyCar(200, 70);
            SportCar sportCar = new SportCar(800, 300);

            crossMotorcycle.Drive(40);
            raceMotorcycle.Drive(25);
            familyCar.Drive(20);
            sportCar.Drive(30);
        }
    }
}
