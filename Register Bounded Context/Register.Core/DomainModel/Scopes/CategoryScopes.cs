using ClotheStore.SharedKernel.Validation;

namespace Register.Core.DomainModel.Scopes
{
    public static class CategoryScopes
    {
        public static bool CreateCategoryScope(this Category category)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(category.Title, ScopesMessage.CategoryTitleIsRequired),
                    AssertionConcern.AssertNotNull(category.Title, ScopesMessage.CategoryTitleIsRequired)
                );
        }
    }
}
