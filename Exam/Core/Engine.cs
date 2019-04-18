namespace FestivalManager.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using Constants;
    using IO.Contracts;
    using Commands;
    using Commands.Contracts;
    using Commands.Factories.Contracts;
    using Controllers.Contracts;
    
	class Engine : IEngine
	{
        private const string EndCommand = "END";

	    private IReader reader;
	    private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        private ICommandFactory commandFactory;

        private bool isRunning;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController,
            ISetController setController, ICommandFactory commandFactory)
        {
            this.isRunning = false;

            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.commandFactory = commandFactory;
        }
        
		public void Run()
		{
            this.isRunning = true;

            while (isRunning)
            {
                string input = this.reader.ReadLine();

                if (input.Equals(EndCommand))
                {
                    this.isRunning = false;
                }

                string result = this.ProcessCommand(input);

                this.writer.WriteLine(result);
            }
		}

		public string ProcessCommand(string input)
		{
            string[] inputArgs = input.Split();

            string[] args = inputArgs.Skip(1).ToArray();

            string commandName = inputArgs[0];

            string result = string.Empty;

            try
            {
                ICommand command = this.commandFactory.CreateCommand(commandName);

                result = command.Execute(args);
            }
            catch(InvalidOperationException ioe)
            {
                result = string.Format(ConstantMessages.Error, ioe.Message);
            }

            return result;
		}
	}
}