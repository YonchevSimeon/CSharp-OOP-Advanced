namespace FestivalManager.Entities.Instruments
{
    using System;

    using Contracts;

    public abstract class Instrument : IInstrument
    {
        private double wear;
        private const int MaxWear = 100;
        private const int MinWear = 0;

        protected Instrument()
        {
            this.Wear = MaxWear;
        }

        public double Wear
        {
            get => this.wear;
            private set
            {

                if (value < MinWear)
                {
                    this.wear = MinWear;
                }
                else
                {
                    this.wear = Math.Min(value, MaxWear);
                }
            }
        }

        protected abstract int RepairAmount { get; }

        public void Repair() => this.Wear += this.RepairAmount;

        public void WearDown() => this.Wear -= this.RepairAmount;

        public bool IsBroken => this.Wear <= 0;

        public override string ToString()
        {
            var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

            return $"{this.GetType().Name} [{instrumentStatus}]";
        }
    }
}
