using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Core.DomainModel.OrderAggregate
{
    public sealed class Order
    {
        private IList<OrderItem> _orderItems;

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public IEnumerable<OrderItem> Itens { get { return _orderItems; } private set { _orderItems = new List<OrderItem>(value); } }

        public Order(IList<OrderItem> orderItems, Guid userId)
        {

            Id = Guid.NewGuid();
            UserId = userId;
            _orderItems = new List<OrderItem>();
            orderItems.ToList().ForEach(item => AddItem(item));
        }

        private void AddItem(OrderItem item)
        {
            _orderItems.Add(item);
        }
    }
}
