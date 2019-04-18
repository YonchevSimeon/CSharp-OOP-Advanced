namespace LoggerExercise.Utilities
{
    using LoggerExercise.Enums;
    using System;

    public static class Utilities
    {
        public const string DATE_FORMAT = "M/d/yyyy h:mm:ss tt";

        public static ErrorType ParseErrorType(string errorTypeString)
        {
            try
            {
                object typeObj = Enum.Parse(typeof(ErrorType), errorTypeString);
                return (ErrorType)typeObj;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid ErrorType!", ae);
            }
        }
    }
}
