using ClotheStore.SharedKernel.Events;
using FluentAssertions;
using Register.Core.DomainModel;
using System;
using Xunit;

namespace GivenAProduct
{
    public class CreateProductFixture
    {
        public CreateProductFixture()
        {
            DomainEvent.Container = null; 
        }
    }
    
    public class WhenCreatedAProductWithoutCategoryId:IClassFixture<CreateProductFixture>
    {
        Product product;

        public WhenCreatedAProductWithoutCategoryId()
        {

            product = new Product(new Guid(), "title Test", "desc test", 1, string.Empty);
        }


        [Fact]
        public void ThenCreationProductScopeIsFalse()
        {
            var actual = product.CreationIsValid();

            actual.Should().Be(false);
        }
    }

    public class WhenCreatedAProductWithoutTitle : IClassFixture<CreateProductFixture>
    {
        Product product;

        public WhenCreatedAProductWithoutTitle()
        {
            product = new Product(Guid.NewGuid(), "", "desc test", 1, string.Empty);
        }


        [Fact]
        public void ThenCreationProductScopeIsFalse()
        {
            var actual = product.CreationIsValid();

            actual.Should().Be(false);
        }
    }

    public class WhenCreatedAProductWithoutDescription : IClassFixture<CreateProductFixture>
    {
        Product product;

        public WhenCreatedAProductWithoutDescription()
        {
            product = new Product(Guid.NewGuid(), "Title", "", 1, string.Empty);
        }


        [Fact]
        public void ThenCreationProductScopeIsFalse()
        {
            var actual = product.CreationIsValid();

            actual.Should().Be(false);
        }
    }

    public class WhenCreatedAProductWithQuantityLessThanZero : IClassFixture<CreateProductFixture>
    {
        Product product;

        public WhenCreatedAProductWithQuantityLessThanZero()
        {
            product = new Product(Guid.NewGuid(), "Title", "desc", -1, string.Empty);
        }


        [Fact]
        public void ThenCreationProductScopeIsFalse()
        {
            var actual = product.CreationIsValid();

            actual.Should().Be(false);
        }
    }
}
