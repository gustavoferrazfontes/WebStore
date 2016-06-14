using System;

namespace Register.Core.ApplicationLayer.Commands
{
    public sealed class RegisterProductCommand
    {
        public Guid CategoryId { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public int QuantityInStock { get; private set; }
        public string Title { get; private set; }

        public RegisterProductCommand(string categoryId, string title, string description, int quantityInStock, string image)
        {
            CategoryId = Guid.Parse(categoryId);
            Title = title;
            Description = description;
            QuantityInStock = quantityInStock;
            Image = image;
        }
    }
}
