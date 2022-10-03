using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.capacity = capacity;
        }

        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
        public int Count
        {
            get { return this.Cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.Cars.Count == this.capacity)
            {
                return "Parking is full!";
            }

            this.Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                this.Cars.Remove(this.Cars.Find(c => c.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.Cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                if (this.Cars.Any(c => c.RegistrationNumber == registrationNumber))
                {
                    this.Cars.Remove(this.Cars.Find(c => c.RegistrationNumber == registrationNumber));
                }
            }
        }
    }
}
