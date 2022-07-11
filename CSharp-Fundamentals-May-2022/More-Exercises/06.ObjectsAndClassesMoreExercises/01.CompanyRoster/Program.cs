using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            for (int i = 0; i < employeesCount; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split(' ');
                string name = employeeInfo[0];
                double salary = double.Parse(employeeInfo[1]);
                string department = employeeInfo[2];

                departments.Add(department);
                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            string bestDepartment = string.Empty;
            double highestAverageSalary = double.MinValue;

            foreach (var department in departments)
            {
                double salarySum = 0;
                int count = 0;

                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].Department == department)
                    {
                        salarySum += employees[i].Salary;
                        count++;
                    }
                }

                double averageSalary = salarySum / count;

                if (averageSalary > highestAverageSalary)
                {
                    highestAverageSalary = averageSalary;
                    bestDepartment = department;
                }
            }

            List<Employee> employeesFromBestDepartment =
                employees.Where(e => e.Department == bestDepartment).OrderByDescending(e => e.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            foreach (var employee in employeesFromBestDepartment)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
    }
}
