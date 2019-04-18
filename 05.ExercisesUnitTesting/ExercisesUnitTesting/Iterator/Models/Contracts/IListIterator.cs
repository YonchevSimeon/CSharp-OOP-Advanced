namespace Iterator.Models.Contracts
{
    using System.Collections.Generic;

    public interface IListIterator
    {
        IList<string> Collection { get; }
        int CurrentIndex { get; }
        bool Move();
        string Print();
        bool HasNext();
    }
}
