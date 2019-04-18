namespace LoggerExercise.Models
{
    using LoggerExercise.Contracts;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if(appender.ErrorType <= error.ErrorType)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
