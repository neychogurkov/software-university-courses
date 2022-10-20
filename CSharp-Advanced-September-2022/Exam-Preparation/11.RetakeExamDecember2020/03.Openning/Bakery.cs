using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.data = new List<Employee>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Employee employee)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name) => this.data.Remove(GetEmployee(name));

        public Employee GetOldestEmployee() => this.data.OrderByDescending(e => e.Age).FirstOrDefault();

        public Employee GetEmployee(string name) => this.data.Find(e => e.Name == name);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}