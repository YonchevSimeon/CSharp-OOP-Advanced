namespace FestivalManager.Core.Commands
{
    using Controllers.Contracts;

    public class RepairInstrumentsCommand : Command
    {
        private IFestivalController festivalController;

        public RepairInstrumentsCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.festivalController.RepairInstruments(args);

            return result;
        }
    }
}
