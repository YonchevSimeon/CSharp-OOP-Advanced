namespace LoggerExercise.Models
{
    using LoggerExercise.Contracts;
    using LoggerExercise.Enums;
    using System;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorType errorType)
        {
            this.Layout = layout;
            this.ErrorType = errorType;
            this.AppendedMessagesCount = 0;
        }

        public int AppendedMessagesCount { get; private set; }

        public ILayout Layout { get; }

        public ErrorType ErrorType { get; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.AppendedMessagesCount++;
        }

        public override string ToString()
        {
            string result =
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ErrorType}, Messages appended: {this.AppendedMessagesCount}";

            return result;
        }
    }
}
