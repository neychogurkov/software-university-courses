﻿namespace MilitaryElite.Models
{
    using Contracts;

    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString() => base.ToString() +  $" Salary: {this.Salary:f2}";
    }
}
