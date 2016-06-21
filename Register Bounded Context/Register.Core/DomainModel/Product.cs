using Register.Core.DomainModel.Scopes;
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
        public Category Category { get; private set; }

        public Product(Guid categoryId, string title, string description, int quantityinStock, string image)
        {
            Id = Guid.NewGuid();
            CategoryId = categoryId;
            Title = title;
            Description = description;
            QuantityInStock = quantityinStock;
            Image = image;
        }

        public bool CreationIsValid()
        {
            return this.CreationProductScope();
        }
    }
}
