namespace WorkForce.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public delegate void GetStatusEventHandler();

    public class Jobs
    {
        public event GetStatusEventHandler GetStatusEvent;

        public Jobs()
        {
            this.JobsList = new List<IJob>();
        }

        public IList<IJob> JobsList { get; private set; }

        public void StatusEvent()
        {
            this.GetStatusEvent?.Invoke();
        }

        public void AddJob(IJob job)
        {
            this.JobsList.Add(job);
            this.GetStatusEvent += job.Status;
        }

        public void RemoveJob(IJob job)
        {
            this.JobsList.Remove(job);
            this.GetStatusEvent -= job.Status;
        }
    }
}
