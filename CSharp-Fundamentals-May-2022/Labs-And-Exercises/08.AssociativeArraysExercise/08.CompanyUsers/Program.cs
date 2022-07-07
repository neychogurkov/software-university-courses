using System;
using System.Collections.Generic;

namespace _08.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> employeesInCompanies = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] companyInfo = Console.ReadLine().Split(" -> ");

                if (companyInfo[0] == "End")
                {
                    break;
                }

                string companyName = companyInfo[0];
                string employeeId = companyInfo[1];

                if (!employeesInCompanies.ContainsKey(companyName))
                {
                    employeesInCompanies[companyName] = new List<string>();
                }

                if (!employeesInCompanies[companyName].Contains(employeeId))
                {
                    employeesInCompanies[companyName].Add(employeeId);
                }
            }

            foreach (var company in employeesInCompanies)
            {
                Console.WriteLine(company.Key);

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
