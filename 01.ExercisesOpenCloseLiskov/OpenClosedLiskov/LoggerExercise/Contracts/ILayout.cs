namespace LoggerExercise.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}