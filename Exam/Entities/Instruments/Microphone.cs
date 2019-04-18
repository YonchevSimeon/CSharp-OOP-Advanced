namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int MicrophoneRepairAmount = 80;

        public Microphone() : base() { }

        protected override int RepairAmount => MicrophoneRepairAmount;
    }
}
