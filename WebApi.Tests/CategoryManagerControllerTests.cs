using ClotheStore.SharedKernel.Events;
using ClotheStore.SharedKernel.Interfaces;
using ConferenceSystem.WebApi.Controllers;
using ConferenceSystem.WebApi.ViewModel;
using FluentAssertions;
using Moq;
using Register.Core.ApplicationLayer.Interfaces;
using Register.Core.ApplicationLayer.Queries;
using Register.Core.DomainModel;
using Register.Core.DomainModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace GivenCategoryManagerController
{
    public class CategoryManagerControllerFixture
    {

        public CategoryManagerController Controller { get; }
        public Mock<ICategoryManager> _mockCategoryManager { get; set; }
        public Mock<INotifiable<DomainNotification>> MockDomainNotification { get; set; }
        public Mock<INotifiable<CategoryRegistered>> MockCategoryRegistered { get; set; }
        public Mock<INotifiable<CategoryUpdated>> MockCategoryUpdated { get; set; }
        public Mock<INotifiable<CategoryRemoved>> MockCategoryRemoved { get; set; }
        public Mock<ICategoryQuery> MockCategoryQuery { get; set; }

        public CategoryManagerControllerFixture()
        {
            _mockCategoryManager = new Mock<ICategoryManager>();
            MockDomainNotification = new Mock<INotifiable<DomainNotification>>();
            MockCategoryRegistered = new Mock<INotifiable<CategoryRegistered>>();
            MockCategoryUpdated = new Mock<INotifiable<CategoryUpdated>>();
            MockCategoryRemoved = new Mock<INotifiable<CategoryRemoved>>();
            MockCategoryQuery = new Mock<ICategoryQuery>();
            Controller = new CategoryManagerController
                (
                    _mockCategoryManager.Object,
                    MockDomainNotification.Object,
                    MockCategoryRegistered.Object,
                    MockCategoryUpdated.Object,
                    MockCategoryRemoved.Object,
                    MockCategoryQuery.Object
                )
            {

                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
    }

    public class WhenGetCategories : IClassFixture<CategoryManagerControllerFixture>
    {
        CategoryManagerControllerFixture _fixture;

        public WhenGetCategories(CategoryManagerControllerFixture fixture)
        {
            _fixture = fixture;
            _fixture.MockCategoryQuery.Setup(_ => _.GetCategories()).Returns(new List<ListOfCategory>() { new ListOfCategory(), new ListOfCategory(), new ListOfCategory() });

        }

        [Fact]
        public void ThenCallGetCategories()
        {
            var actual = _fixture.Controller.GetAsync().Result as OkNegotiatedContentResult<IEnumerable<ListOfCategory>>;
            actual.Should().NotBeNull();
            actual.Content.Should().NotBeNull();
            actual.Content.Count().Should().Be(3);
        }
    }

    public class WhenCreateCategory : IClassFixture<CategoryManagerControllerFixture>
    {
        CategoryManagerControllerFixture _fixture;
        List<CategoryRegistered> _lstSuccessNotifications;
        public WhenCreateCategory(CategoryManagerControllerFixture fixture)
        {
            _lstSuccessNotifications = new List<CategoryRegistered>();
            _lstSuccessNotifications.Add(new CategoryRegistered(new Category("title test")));

            _fixture = fixture;

            _fixture.MockCategoryRegistered.Setup(_ => _.Notify())
                .Returns(_lstSuccessNotifications);

        }

        [Fact]
        public void ThenCallRegister()
        {
            var newCategory = new NewCategory { Title = "title test" };
            var actual = _fixture.Controller.PostAsync(newCategory).Result as OkNegotiatedContentResult<IEnumerable<CategoryRegistered>>;
            actual.Should().NotBeNull();
            actual.Content.Should().NotBeNull();
            actual.Content.Count().Should().Be(1);
        }
    }

    public class WhenUpdateCategory : IClassFixture<CategoryManagerControllerFixture>
    {
        CategoryManagerControllerFixture _fixture;
        List<CategoryUpdated> _lstCategoriesUpdated;
        public WhenUpdateCategory(CategoryManagerControllerFixture fixture)
        {
            _lstCategoriesUpdated = new List<CategoryUpdated>();
            _lstCategoriesUpdated.Add(new CategoryUpdated(new Category("title updated")));
            _fixture = fixture;

            _fixture.MockCategoryUpdated.Setup(_ => _.Notify())
            .Returns(_lstCategoriesUpdated);
        }

        [Fact]
        public void ThenCallUpdate()
        {
            var updateCategory = new UpdateCategory { Title = "title updated", Id = Guid.NewGuid().ToString() };
            var actual = _fixture.Controller.PutAsync(updateCategory).Result as OkNegotiatedContentResult<IEnumerable<CategoryUpdated>>;

            actual.Content.Should().NotBeNull();
            actual.Content.Count().Should().Be(1);
        }
    }

    public class WhenDeleteCategory : IClassFixture<CategoryManagerControllerFixture>
    {
        CategoryManagerControllerFixture _fixture;
        List<CategoryRemoved> _lstCategoriesRemoved;
        public WhenDeleteCategory(CategoryManagerControllerFixture fixture)
        {
            _lstCategoriesRemoved = new List<CategoryRemoved>();
            _lstCategoriesRemoved.Add(new CategoryRemoved(Guid.NewGuid()));
            _fixture = fixture;

            _fixture.MockCategoryRemoved.Setup(_ => _.Notify())
           .Returns(_lstCategoriesRemoved);
        }

        [Fact]
        public void ThenCallDelete()
        {
            var deleteCategory = Guid.NewGuid().ToString();
            var actual = _fixture.Controller.DeleteAsync(deleteCategory).Result as OkNegotiatedContentResult<IEnumerable<CategoryRemoved>>;

            actual.Content.Should().NotBeNull();
            actual.Content.Count().Should().Be(1);
        }
    }


}
