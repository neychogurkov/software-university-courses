using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            firstCar.Drive(5);
            Console.WriteLine(firstCar.WhoAmI());

            secondCar.Drive(20);
            Console.WriteLine(secondCar.WhoAmI());

            thirdCar.Drive(15);
            Console.WriteLine(thirdCar.WhoAmI());
        }
    }
}