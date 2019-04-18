namespace FestivalManager.Core.Commands
{
    using Core.Controllers.Contracts;

    public class RegisterSetCommand : Command
    {
        private IFestivalController festivalController;

        public RegisterSetCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.festivalController.RegisterSet(args);

            return result;
        }
    }
}
