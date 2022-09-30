using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "Mercedes";
            car.Model = "GT 63 AMG";
            car.Year = 2019;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;

            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
        }
    }
}