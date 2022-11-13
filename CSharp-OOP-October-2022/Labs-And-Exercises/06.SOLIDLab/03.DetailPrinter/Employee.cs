namespace DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
