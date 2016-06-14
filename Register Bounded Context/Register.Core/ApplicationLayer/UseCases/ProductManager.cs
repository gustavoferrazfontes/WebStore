using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using Register.Core.ApplicationLayer.Commands;
using Register.Core.ApplicationLayer.Interfaces;
using Register.Core.DomainModel;
using Register.Core.DomainModel.Events;
using Register.Core.DomainModel.Interfaces.Repository;

namespace Register.Core.ApplicationLayer.UseCases
{
    public sealed class ProductManager : UseCaseBase, IProductManager
    {

        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository, INotifiable<DomainNotification> notification, IUnitOfWork uow) : base(notification, uow)
        {
            _productRepository = productRepository;
        }

        public void RegisterProduct(RegisterProductCommand command)
        {
            var newProduct = new Product
                (
                    command.CategoryId,
                    command.Title,
                    command.Description,
                    command.QuantityInStock,
                    command.Image
                 );

            newProduct.CreationIsValid();
            _productRepository.SaveNewProduct(newProduct);
            if (Commit())
            {
                DomainEvent.Raise(new ProductRegistered(newProduct));
            }
        }
    }
}
