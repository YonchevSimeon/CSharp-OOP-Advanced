namespace Integration.Models.Contracts
{
    using System.Collections.Generic;

    public interface IUser : IName
    {
        ISet<ICategory> Categories { get; }
        void AddCategory(ICategory category);
        void RemoveCategory(ICategory category);
    }
}
