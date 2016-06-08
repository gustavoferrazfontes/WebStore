using System;

namespace Order.Core.DomainModel.OrderAggregate
{
    public sealed class OrderItem
    {
        
        public Guid ProductId { get; private set; }
        public Guid OrderId { get; private set; }
        public int Quantity { get; private set; }


        public OrderItem(Guid productId, Guid orderId, int quantity)
        {
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }


    }
}