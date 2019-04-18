﻿namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int DrumsRepairAmount = 20;

        public Drums() : base() { }

        protected override int RepairAmount => DrumsRepairAmount;
    }
}
