namespace WorkForce.Models.Factories
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JobFactory
    {
        public IJob CreateJob(string[] args, IList<IEmployee> employees)
        {
            string jobName = args[1];
            int workHoursRequired = int.Parse(args[2]);
            string employeeName = args[3];

            IEmployee employee = employees.First(e => e.Name == employeeName);

            return new Job(jobName, workHoursRequired, employee);
        }
    }
}
