namespace WorkForce.Models
{
    using System;
    using Contracts;

    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public int WorkHoursPerWeek { get; private set; }

        public string Name { get; private set; }
    }
}
