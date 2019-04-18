namespace DateTimeNow.Models.Contracts
{
    using System;

    public interface IDatetime
    {
        DateTime Now();
        void AddDays(DateTime dt, int days);
    }
}
