using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using FluentAssertions;
using Moq;
using Moq.Sequences;
using Register.Core.ApplicationLayer.Commands;
using Register.Core.ApplicationLayer.Handlers;
using Register.Core.ApplicationLayer.Interfaces;
using Register.Core.ApplicationLayer.UseCases;
using Register.Core.DomainModel;
using Register.Core.DomainModel.Interfaces.Repository;
using System;
using Xunit;

namespace GivenARegisterProduct
{

    public class ProductManagerFixture
    {
        public Mock<IProductRepository> MockProductRepository { get; private set; }
        public Mock<INotifiable<DomainNotification>> NotifiableDomainNotification { get; private set; }
        public Mock<IUnitOfWork> MockUnitOfWork { get; private set; }
        public IProductManager ProductManager { get; private set; }
        public Mock<IContainer> MockContainer { get; private set; }
        public ProductRegisteredHandler handler;

        public ProductManagerFixture()
        {
            NotifiableDomainNotification = new Mock<INotifiable<DomainNotification>>();
            MockProductRepository = new Mock<IProductRepository>();
            MockUnitOfWork = new Mock<IUnitOfWork>();
            ProductManager = new ProductManager(MockProductRepository.Object, NotifiableDomainNotification.Object, MockUnitOfWork.Object);
            MockContainer = new Mock<IContainer>();
            handler = new ProductRegisteredHandler();

        }


    }

    public class WhenCreateAProduct : IClassFixture<ProductManagerFixture>
    {
        ProductManagerFixture _fixture;
        RegisterProductCommand command;

        public WhenCreateAProduct(ProductManagerFixture fixture)
        {
            _fixture = fixture;
            _fixture.MockContainer.Setup(_ => _.GetService(It.IsAny<Type>())).Returns(_fixture.handler);
            DomainEvent.Container = _fixture.MockContainer.Object;

            command = new RegisterProductCommand(Guid.NewGuid().ToString(), "Title teste", "description teste", 10, string.Empty);
        }

        [Fact]
        public void ThenAddCallToRepository()
        {
            
            using (Sequence.Create())
            {

                _fixture.MockProductRepository.Setup(_ => _.SaveNewProduct(It.IsAny<Product>())).InSequence();
                _fixture.MockUnitOfWork.Setup(_ => _.Commit()).InSequence();

                _fixture.ProductManager.RegisterProduct(command);
            }
        }

        [Fact]
        public void ThenNotifyThatProductWasRegistered()
        {
            _fixture.handler.HasNotifications().Should().Be(true);
        }


    }
}
