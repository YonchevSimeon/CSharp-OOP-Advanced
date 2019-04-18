using LoggerExercise.Enums;

namespace LoggerExercise.Contracts
{
    public interface IAppender
    {
        int AppendedMessagesCount { get; }

        ILayout Layout { get; }

        ErrorType ErrorType { get; }

        void Append(IError error);
    }
}
