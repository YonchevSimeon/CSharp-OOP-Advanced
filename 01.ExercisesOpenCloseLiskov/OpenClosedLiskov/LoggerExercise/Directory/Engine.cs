namespace LoggerExercise.Directory
{
    using LoggerExercise.Contracts;
    using System;

    public class Engine
    {
        private EngineDependencies engineDependencies;
        private ILogger logger;

        public Engine()
        {
            this.engineDependencies = new EngineDependencies();
            this.logger = this.engineDependencies.GetLogger();
        }

        public void Run()
        {
            string input;
            try
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    IError error = this.GetError(input);

                    logger.Log(error);
                }
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }

        private IError GetError(string input)
        {
            string[] errArgs = input.Split('|');
            
            string errorType = errArgs[0];
            string dateTime = errArgs[1];
            string message = errArgs[2];

            IError error = this.engineDependencies.ErrorFactory.CreateError(dateTime, errorType, message);

            return error;
        }
    }
}
