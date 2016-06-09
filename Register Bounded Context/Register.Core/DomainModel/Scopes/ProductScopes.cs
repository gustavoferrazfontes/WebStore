using ClotheStore.SharedKernel.Validation;
using System;

namespace Register.Core.DomainModel.Scopes
{
    public static class ProductScopes
    {

        public static bool CreationProductScope(this Product product)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertAreNotEquals(product.CategoryId.ToString(), new Guid().ToString(), ScopesMessage.ProductCategoryIdInvalid),
                    AssertionConcern.AssertNotEmpty(product.Title, ScopesMessage.ProductTitleIsRequired),
                    AssertionConcern.AssertNotNull(product.Title, ScopesMessage.ProductTitleIsRequired),
                    AssertionConcern.AssertNotEmpty(product.Description, ScopesMessage.ProductDescriptionIsRequired),
                    AssertionConcern.AssertNotNull(product.Description, ScopesMessage.ProductDescriptionIsRequired),
                    AssertionConcern.AssertIsGreaterOrEqualThan(product.QuantityInStock, 0, ScopesMessage.ProductQuantityIsInvalid)


                );
        }
    }
}

