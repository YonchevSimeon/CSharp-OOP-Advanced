namespace LoggerExercise.Contracts
{
    using LoggerExercise.Enums;
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        ErrorType ErrorType { get; }

        string Message { get; }
    }
}