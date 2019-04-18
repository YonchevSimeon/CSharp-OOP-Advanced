namespace DateTimeNow.Models
{
    using Contracts;
    using System;

    public class Datetime : IDatetime
    {
        public void AddDays(DateTime dt, int days) => dt.AddDays(days);

        public DateTime Now() => DateTime.Now;
    }
}
