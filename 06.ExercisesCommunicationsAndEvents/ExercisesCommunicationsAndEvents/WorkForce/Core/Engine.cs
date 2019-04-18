namespace WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using Models.Contracts;
    using Models.Factories;
    using WorkForce.Models;

    public class Engine
    {
        private IList<IEmployee> employees;
        private Jobs jobs;
        private EmployeeFactory employeeFactory;
        private JobFactory jobFactory;

        public Engine()
        {
            this.employees = new List<IEmployee>();
            this.jobs = new Jobs();
            this.employeeFactory = new EmployeeFactory();
            this.jobFactory = new JobFactory();
        }

        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                switch (command)
                {
                    case "Job":
                        IJob newJob = this.jobFactory.CreateJob(inputArgs, this.employees);
                        this.jobs.AddJob(newJob);
                        break;

                    case "StandardEmployee":
                    case "PartTimeEmployee":
                        IEmployee newEmployee = this.employeeFactory.CreateEmployee(inputArgs);
                        this.employees.Add(newEmployee);
                        break;

                    case "Pass":
                        foreach (IJob job in this.jobs.JobsList)
                        {
                            job.Update();
                        }
                        CheckForFinishedJobs();
                        break;

                    case "Status":
                        this.jobs.StatusEvent();
                        break;
                }
            }
        }

        private void CheckForFinishedJobs()
        {
            for (int index = 0; index < this.jobs.JobsList.Count; index++)
            {
                IJob job = this.jobs.JobsList[index];

                if (job.IsJobDone)
                {
                    job.Status();
                    this.jobs.RemoveJob(job);
                }
            }
        }
    }
}
