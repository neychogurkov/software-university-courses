using System;

namespace _02.Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int doctors = 7;
            int days = int.Parse(Console.ReadLine());
            int treatedPatients = 0;
            int untreatedPatients = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0)
                {
                    if (untreatedPatients > treatedPatients)
                    {
                        doctors++;
                    }
                }

                int patients = int.Parse(Console.ReadLine());

                if (patients > doctors)
                {
                    treatedPatients += doctors;
                    untreatedPatients += patients-doctors;
                }
                else
                {
                    treatedPatients += patients;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");

        }
    }
}
