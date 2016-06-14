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
using System.Linq;
using Xunit;

namespace GivenARegisterCategory
{

    
    public class RegisterCategoryFixture
    {

        public IRegisterCategory registerCategory;
        public Mock<ICategoryRepository> _mockCategoryRepository;
        public CategoryRegisteredHandler _CategoryRegisteredHandler;
        public Mock<INotifiable<DomainNotification>> _mockDomainNotification;
        public Mock<IUnitOfWork> _mockUnitOfWork;
        public Mock<IContainer> _mockContainerEvent;

        public RegisterCategoryFixture()
        {

            _mockCategoryRepository = new Mock<ICategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockDomainNotification = new Mock<INotifiable<DomainNotification>>();
            _CategoryRegisteredHandler = new CategoryRegisteredHandler();
            registerCategory = new RegisterCategory(_mockCategoryRepository.Object, _mockDomainNotification.Object, _mockUnitOfWork.Object);


        }


    }

    public class WhenCreateACategory : IClassFixture<RegisterCategoryFixture>
    {

        RegisterCategoryFixture _fixture;
        public WhenCreateACategory(RegisterCategoryFixture fixture)
        {
            _fixture = fixture;
            _fixture._mockContainerEvent = new Mock<IContainer>();
            _fixture._mockContainerEvent.Setup(_ => _.GetService(It.IsAny<Type>())).Returns(_fixture._CategoryRegisteredHandler);
            DomainEvent.Container = _fixture._mockContainerEvent.Object;
        }


        [Fact]
        public void ThenAddCallToRepository()
        {
            var command = new RegisterCategoryCommand("Test Category");

            using (Sequence.Create())
            {

                _fixture._mockCategoryRepository.Setup(_ => _.SaveNewCategory(It.IsAny<Category>())).InSequence();
                _fixture._mockUnitOfWork.Setup(_ => _.Commit()).InSequence();

                _fixture.registerCategory.Register(command);
            }
        }

        [Fact]
        public void ThenNotifyThatCategorywasRegistered()
        {
            _fixture._CategoryRegisteredHandler.Notify().Count().Should().Be(1);
        }
    }
}
