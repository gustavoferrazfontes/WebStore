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
}
