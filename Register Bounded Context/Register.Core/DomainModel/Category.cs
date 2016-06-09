using Register.Core.DomainModel.Scopes;
using System;
namespace Register.Core.DomainModel
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        public Category(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }

        public bool CreationIsValid()
        {
            return this.CreateCategoryScope();
        }
    }
}
