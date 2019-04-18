namespace LoggerExercise.Models
{
    using LoggerExercise.Contracts;
    using LoggerExercise.Enums;
    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorType errorType, string message)
        {
            this.DateTime = dateTime;
            this.ErrorType = errorType;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public ErrorType ErrorType { get; }

        public string Message { get; }
    }
}
