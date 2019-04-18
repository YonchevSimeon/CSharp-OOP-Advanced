namespace DateTimeNowTests
{
    using DateTimeNow.Models;
    using DateTimeNow.Models.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatetimeTests
    {
        private IDatetime dt;

        [SetUp]
        public void CreateDatetime()
        {
            this.dt = new Datetime();
        }

        [Test]
        public void DatetimeNowSeconds()
        {
            Assert.That(this.dt.Now().Second, Is.EqualTo(DateTime.Now.Second), 
                "Difference in the seconds");
        }

        [Test]
        public void DatetimeNowMinutes()
        {
            Assert.That(this.dt.Now().Minute, Is.EqualTo(DateTime.Now.Minute), 
                "Difference in the minutes");
        }

        [Test]
        public void DatetimeNowHour()
        {
            Assert.That(this.dt.Now().Hour, Is.EqualTo(DateTime.Now.Hour), 
                "Difference in the hours");
        }

        [Test]
        public void DatetimeNowDay()
        {
            Assert.That(this.dt.Now().Day, Is.EqualTo(DateTime.Now.Day), 
                "Difference in the days");
        }

        [Test]
        public void DatetimeNowMonth()
        {
            Assert.That(this.dt.Now().Month, Is.EqualTo(DateTime.Now.Month), 
                "Difference in the months");
        }

        [Test]
        public void DatetimeNowYear()
        {
            Assert.That(this.dt.Now().Year, Is.EqualTo(DateTime.Now.Year), 
                "Difference in the years");
        }
        
        [Test]
        public void DatetimeNowDate()
        {
            Assert.That(this.dt.Now().Date, Is.EqualTo(DateTime.Now.Date), 
                "Difference in the dates");
        }

        [Test]
        [TestCase(1, 1000, 01, 15)]
        [TestCase(1, 1000, 01, 30)]
        public void AddDay(int daysToAdd, int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);

            DateTime output = new DateTime(year, month, day + daysToAdd);

            Assert.That(date.AddDays(daysToAdd).Date, Is.EqualTo(output.Date), 
                "Differene in the dates");
        }

    }
}
