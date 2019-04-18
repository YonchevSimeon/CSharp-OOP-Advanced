namespace LoggerExercise.Directory
{
    using LoggerExercise.Contracts;
    using LoggerExercise.Factories;
    using LoggerExercise.Models;
    using System.Collections.Generic;
    using System;

    public class EngineDependencies
    {
        private LayoutFactory layoutFactory;
        private AppenderFactory appenderFactory;

        public EngineDependencies()
        {
            try
            {
                this.ErrorFactory = new ErrorFactory();
                this.layoutFactory = new LayoutFactory();
                this.appenderFactory = new AppenderFactory(this.layoutFactory);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        
        public ErrorFactory ErrorFactory { get; }

        public ILogger GetLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            
            int appendersCount = int.Parse(Console.ReadLine());

            for (int index = 0; index < appendersCount; index++)
            {
                string[] appArgs = Console.ReadLine().Split();

                string appenderType = appArgs[0];
                string layoutType = appArgs[1];
                string errorType = "INFO";

                if(appArgs.Length == 3)
                {
                    errorType = appArgs[2];
                }

                try
                {
                    IAppender appender = this.appenderFactory.CreateAppender(appenderType, errorType, layoutType);

                    appenders.Add(appender);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}
