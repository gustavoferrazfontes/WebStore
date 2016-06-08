using System;
namespace Register.Core.DomainModel
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
    }
}
