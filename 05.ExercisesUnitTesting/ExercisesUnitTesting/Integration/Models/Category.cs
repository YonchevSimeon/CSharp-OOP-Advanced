namespace Integration.Models
{
    using Contracts;
    using System.Linq;
    using System.Collections.Generic;

    public class Category : ICategory
    {
        public Category(string name)
        {
            this.Name = name;
            this.Users = new HashSet<IUser>();
            this.ChildrenCategories = new HashSet<ICategory>();
        }

        public ISet<IUser> Users { get; private set; }

        public ISet<ICategory> ChildrenCategories { get; private set; }

        public string Name { get; private set; }

        public ICategory ParentCategory { get; private set; }

        public void AddUser(IUser user)
        {
            this.Users.Add(user);
            user.AddCategory(this);
        }

        public void AddChild(ICategory category)
        {
            this.ChildrenCategories.Add(category);
            category.SetParentCategory(this);
        }

        public void RemoveChild(ICategory category)
        {
            ICategory[] childrenCategories = category.ChildrenCategories.ToArray();

            if(childrenCategories.Length > 0)
            {
                IUser[] users = category.Users.ToArray();
                foreach (ICategory child in childrenCategories)
                {
                    foreach (IUser user in users)
                    {
                        child.AddUser(user);
                    }
                }
            }

            this.ChildrenCategories.Remove(category);
        }

        public void SetParentCategory(ICategory category)
        {
            this.ParentCategory = category;
        }
    }
}
