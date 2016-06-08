using System;

namespace Register.Core.DomainModel
{
    public sealed class Product
    {
        public Guid Id { get; private set; }
        public Guid CategoryId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int QuantityInStock { get; private set; }
        public string Image { get; private set; }
    }
}
