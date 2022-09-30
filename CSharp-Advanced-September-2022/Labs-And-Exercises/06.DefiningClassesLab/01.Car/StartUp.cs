using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "Mercedes";
            car.Model = "GT 63";
            car.Year = 2019;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
