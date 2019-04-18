namespace ExtendedDatabase.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        IList<IPerson> People { get; }
        int Count { get; }
        void Add(IPerson person);
        void Remove(IPerson person);
        IPerson FindBy(string username);
        IPerson FindBy(long id);
    }
}
