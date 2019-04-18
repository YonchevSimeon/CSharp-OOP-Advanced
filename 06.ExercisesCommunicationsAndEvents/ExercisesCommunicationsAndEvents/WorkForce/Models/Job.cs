namespace WorkForce.Models
{
    using System;
    using Contracts;

    public class Job : IJob
    {
        public Job(string name, int workHoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.Employee = employee;
        }

        public int WorkHoursRequired { get; private set; }

        public IEmployee Employee { get; private set; }

        public string Name { get; private set; }

        public bool IsJobDone { get; private set; } = false;

        public void Update()
        {
            this.WorkHoursRequired -= this.Employee.WorkHoursPerWeek;
            if(this.WorkHoursRequired <= 0)
            {
                this.IsJobDone = true;
            }
        }

        public void Status()
        {
            if (this.IsJobDone)
            {
                Console.WriteLine($"{this.GetType().Name} {this.Name} done!");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name}: {this.Name} Hours Remaining: {this.WorkHoursRequired}");
            }
        }
    }
}
