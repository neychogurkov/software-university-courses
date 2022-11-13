using System;

namespace DetailPrinter
{
    public class QAEngineer : Employee
    {
        public QAEngineer(string name, int bugsFixedToday) 
            : base(name)
        {
            this.BugsFixedToday = bugsFixedToday;
        }

        public int BugsFixedToday { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + this.BugsFixedToday;
        }
    }
}
