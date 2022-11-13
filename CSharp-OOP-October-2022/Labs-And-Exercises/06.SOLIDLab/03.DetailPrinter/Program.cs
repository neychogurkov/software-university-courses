using System.Collections.Generic;

namespace DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IList<IEmployee> employees = new List<IEmployee>();
            employees.Add(new Employee("George"));
            employees.Add(new Manager("Peter", new List<string>() { "Document 1", "Document 2", "Document 3"}));
            employees.Add(new QAEngineer("John", 12));

            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
