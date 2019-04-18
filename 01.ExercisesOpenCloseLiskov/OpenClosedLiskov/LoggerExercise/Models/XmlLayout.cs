namespace LoggerExercise.Models
{
    using LoggerExercise.Utilities;
    using LoggerExercise.Contracts;
    using System.Globalization;
    using System;

    public class XmlLayout : ILayout
    {
       private string FORMAT_ERROR =
            "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level>" + Environment.NewLine +
            "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";


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
