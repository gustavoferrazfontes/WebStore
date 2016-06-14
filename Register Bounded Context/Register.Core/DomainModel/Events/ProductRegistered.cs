using ClotheStore.SharedKernel.Events.Interfaces;
using System;

namespace Register.Core.DomainModel.Events
{
    public sealed class ProductRegistered : IDomainEvent
    {
        private DateTime _dateOccured;
        public DateTime DateOccurred
        {
            get
            {
                return _dateOccured;
            }
        }

        public string ProductName { get; private set; }
        public string Id { get; private set; }

        public ProductRegistered(Product newProduct)
        {
            _dateOccured = DateTime.Now;
            ProductName = newProduct.Title;
            Id = newProduct.Id.ToString();

        }
    }
}
