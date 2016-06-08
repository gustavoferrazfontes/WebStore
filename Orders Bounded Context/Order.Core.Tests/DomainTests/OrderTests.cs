using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using Order.Core.DomainModel.OrderAggregate;
using System.Collections.Generic;

namespace GivenAnOrder
{

    public class WhenClientMakeAnOrder
    {
        Order.Core.DomainModel.OrderAggregate.Order newOrder;
        List<OrderItem> orderItems;
        public WhenClientMakeAnOrder()
        {
            orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem(Guid.NewGuid(), Guid.NewGuid(), 1));
            newOrder = new Order.Core.DomainModel.OrderAggregate.Order(orderItems, Guid.NewGuid());
        }

        [Fact]
        public void ThenOrderIsCreated()
        {
            Assert.NotNull(newOrder);
        }

        [Fact]
        public void ThenOrderMustHaveAnId()
        {
            newOrder.Id.Should().NotBe(new Guid());
        }

        [Fact]
        public void ThenOrderMustHaveAnUserId()
        {
            newOrder.UserId.Should().NotBe(new Guid());
        }

        [Fact]
        public void ThenOrderMustHaveAtLeastOneOrderItem()
        {
            newOrder.Itens.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void ThenOrderItemMustHaveProductId()
        {
            newOrder.Itens.First().ProductId.Should().NotBe(new Guid());
        }

        [Fact]
        public void ThenQuantityOfOrderItemMustBeGreaterThanZero()
        {
            newOrder.Itens.First().Quantity.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ThenOrderItemMustHaveOrderId()
        {
            newOrder.Itens.First().OrderId.Should().NotBe(new Guid());
        }
    }
}
