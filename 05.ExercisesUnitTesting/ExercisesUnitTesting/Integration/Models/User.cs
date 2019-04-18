namespace Integration.Models
{
    using Contracts;
    using System.Linq;
    using System.Collections.Generic;

    public class User : IUser
    {
        public User(string name)
        {
            this.Name = name;
            this.Categories = new HashSet<ICategory>();
        }

        public ISet<ICategory> Categories { get; private set; }

        public string Name { get; private set; }

        public void AddCategory(ICategory category)
        {
            this.Categories.Add(category);
        }

        public void RemoveCategory(ICategory category)
        {
            this.Categories.Remove(category);
        }
    }
}
