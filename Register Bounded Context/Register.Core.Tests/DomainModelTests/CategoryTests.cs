using Register.Core.DomainModel;
using Xunit;
using FluentAssertions;
namespace GivenACategory
{
    public class WhenCreateCategoryWithNullOrEmptyTitle
    {
        Category newCategory;
        public WhenCreateCategoryWithNullOrEmptyTitle()
        {
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
