namespace FestivalManager.Core.Commands
{
    using Controllers.Contracts;

    public class ENDCommand : Command
    {
        private IFestivalController festivalController;

        public ENDCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.festivalController.ProduceReport();

            return result;
        }
    }
}
