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


    public class CategoryManagerFixture
    {

        public ICategoryManager managerCategory;
        public Mock<ICategoryRepository> _mockCategoryRepository;
        public CategoryRegisteredHandler _CategoryRegisteredHandler;
        public CategoryRemovedHandler _categoryRemovedHandler;
        public CategoryUpdatedHandler _categoryChangedHandler;
        public Mock<INotifiable<DomainNotification>> _mockDomainNotification;
        public Mock<IUnitOfWork> _mockUnitOfWork;
        public Mock<IContainer> _mockContainerEvent;

        public CategoryManagerFixture()
        {

            _mockCategoryRepository = new Mock<ICategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockDomainNotification = new Mock<INotifiable<DomainNotification>>();
            _CategoryRegisteredHandler = new CategoryRegisteredHandler();
            _categoryRemovedHandler = new CategoryRemovedHandler();
            _categoryChangedHandler = new CategoryUpdatedHandler();
            _mockContainerEvent = new Mock<IContainer>();
            managerCategory = new CategoryManager(_mockCategoryRepository.Object, _mockDomainNotification.Object, _mockUnitOfWork.Object);


        }


    }

    public class WhenCreateACategory : IClassFixture<CategoryManagerFixture>
    {

        CategoryManagerFixture _fixture;
        RegisterCategoryCommand command;
        public WhenCreateACategory(CategoryManagerFixture fixture)
        {
            _fixture = fixture;
            _fixture._mockContainerEvent.Setup(_ => _.GetService(It.IsAny<Type>())).Returns(_fixture._CategoryRegisteredHandler);
            DomainEvent.Container = _fixture._mockContainerEvent.Object;

            command = new RegisterCategoryCommand("Test Category");
        }


        [Fact]
        public void ThenAddCallToRepository()
        {


            using (Sequence.Create())
            {

                _fixture._mockCategoryRepository.Setup(_ => _.SaveNewCategory(It.IsAny<Category>())).InSequence();
                _fixture._mockUnitOfWork.Setup(_ => _.Commit()).InSequence();

                _fixture.managerCategory.Register(command);
            }
        }

        [Fact]
        public void ThenNotifyThatCategoryWasRegistered()
        {
            _fixture.managerCategory.Register(command);
            _fixture._CategoryRegisteredHandler.HasNotifications().Should().Be(true);
        }
    }

    public class WhenDeleteACategory : IClassFixture<CategoryManagerFixture>
    {
        CategoryManagerFixture _fixture;
        RemoveCategoryCommand command;
        public WhenDeleteACategory(CategoryManagerFixture fixture)
        {
            _fixture = fixture;
            command = new RemoveCategoryCommand(Guid.NewGuid().ToString());
            _fixture._mockContainerEvent.Setup(_ => _.GetService(It.IsAny<Type>())).Returns(_fixture._categoryRemovedHandler);
            DomainEvent.Container = _fixture._mockContainerEvent.Object;
        }

        [Fact]
        public void ThenAddCallToRepository()
        {
            using (Sequence.Create())
            {
                _fixture._mockCategoryRepository.Setup(_ => _.Remove(It.IsAny<Guid>())).InSequence();
                _fixture._mockUnitOfWork.Setup(_ => _.Commit()).InSequence();

                _fixture.managerCategory.Remove(command);
            }
        }

        [Fact]
        public void ThenNotifyThatCategoryWasRemoved()
        {
            _fixture.managerCategory.Remove(command);
            _fixture._categoryRemovedHandler.HasNotifications().Should().Be(true);
        }
    }

    public class WhenUpdateACategory : IClassFixture<CategoryManagerFixture>
    {
        CategoryManagerFixture _fixture;
        UpdateCategoryCommand command;
        Category categoryFound;
        public WhenUpdateACategory(CategoryManagerFixture fixture)
        {
            _fixture = fixture;

            categoryFound = new Category("Title test");
            command = new UpdateCategoryCommand("title updated");

            _fixture._mockContainerEvent.Setup(_ => _.GetService(It.IsAny<Type>())).Returns(_fixture._categoryChangedHandler);
            DomainEvent.Container = _fixture._mockContainerEvent.Object;
        }


        [Fact]
        public void ThenAddCallToRepository()
        {
            using (Sequence.Create())
            {
                _fixture._mockCategoryRepository.Setup(_ => _.GetCategory(It.IsAny<Guid>())).InSequence().Returns(categoryFound);
                _fixture._mockUnitOfWork.Setup(_ => _.Commit());

                _fixture.managerCategory.Update(command);
            }
        }

        [Fact]
        public void ThenNotifyThatCategoryWasRemoved()
        {
            _fixture._mockCategoryRepository.Setup(_ => _.GetCategory(It.IsAny<Guid>())).Returns(categoryFound);
            _fixture.managerCategory.Update(command);
            _fixture._categoryChangedHandler.HasNotifications().Should().Be(true);
        }

    }
}
