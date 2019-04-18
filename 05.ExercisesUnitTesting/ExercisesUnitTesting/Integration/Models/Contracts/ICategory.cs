namespace Integration.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICategory : IName
    {
        ISet<IUser> Users { get; }
        ISet<ICategory> ChildrenCategories { get; }
        ICategory ParentCategory { get; }
        void AddUser(IUser user);
        void AddChild(ICategory category);
        void RemoveChild(ICategory category);
        void SetParentCategory(ICategory category);
    }
}
