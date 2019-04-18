namespace LoggerExercise.Factories
{
    using LoggerExercise.Utilities;
    using LoggerExercise.Contracts;
    using LoggerExercise.Enums;
    using LoggerExercise.Models;
    using System.Globalization;
    using System;

    public class ErrorFactory
    { 
        public IError CreateError(string dateTimeString, string errorTypeString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, Utilities.DATE_FORMAT, CultureInfo.InvariantCulture);

            ErrorType errorType = Utilities.ParseErrorType(errorTypeString);

            IError error = new Error(dateTime, errorType, message);
            
            return error;
        }
    }
}
