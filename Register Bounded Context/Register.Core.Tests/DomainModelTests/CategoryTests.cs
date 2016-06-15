using Register.Core.DomainModel;
using Xunit;
using FluentAssertions;
using ClotheStore.SharedKernel.Events;

namespace GivenACategory
{

    public class WhenCreateCategoryWithNullOrEmptyTitle
    {
        Category newCategory;
        public WhenCreateCategoryWithNullOrEmptyTitle()
        {
            DomainEvent.Container = null;
            newCategory = new Category("");
        }

        [Fact]
        public void ThenScopeCreateCategoryIsFalse()
        {
            var actual = newCategory.CreationIsValid();
            actual.Should().Be(false);
        }
    }

    public class WhenUpdateACategory
    {
        Category newCategory;
        public WhenUpdateACategory()
        {
            DomainEvent.Container = null;
            newCategory = new Category("title");
            newCategory.ChangeData("new title");
        }

        [Fact]
        public void ThenChangeTheTitle()
        {
            newCategory.Title.Should().Be("new title");
        }
    }
}
