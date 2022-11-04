using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] citizenInfo = Console.ReadLine().Split();

                if (citizenInfo[0] == "End")
                {
                    break;
                }

                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);

                Citizen citizen = new Citizen(name, country, age);
                IResident resident = citizen;
                IPerson person = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
