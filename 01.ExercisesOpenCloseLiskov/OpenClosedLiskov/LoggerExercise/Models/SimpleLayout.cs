namespace LoggerExercise.Models
{
    using LoggerExercise.Contracts;
    using LoggerExercise.Utilities;
    using System.Globalization;

    public class SimpleLayout : ILayout
    {
        
        const string FORMAT_ERROR = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(
                Utilities.DATE_FORMAT, 
                CultureInfo.InvariantCulture
                );
            string formattedError = string.Format(
                FORMAT_ERROR, 
                dateString, 
                error.ErrorType.ToString(), 
                error.Message
                );

            return formattedError;
        }
    }
}
