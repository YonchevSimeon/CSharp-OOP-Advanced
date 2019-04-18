namespace LoggerExercise.Factories
{
    using System;
    using LoggerExercise.Contracts;
    using LoggerExercise.Enums;
    using LoggerExercise.Models;
    using LoggerExercise.Utilities;

    public class AppenderFactory
    {
        const string DEFAULT_FILE_NAME = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int logFileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string errorTypeString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            ErrorType errorType = Utilities.ParseErrorType(errorTypeString);

            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorType);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DEFAULT_FILE_NAME, this.logFileNumber));
                    appender = new FileAppender(layout, errorType, logFile);
                    this.logFileNumber++;
                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

            return appender;
        }
        
    }
}
