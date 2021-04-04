using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainModel
{
    public interface IOrder : IIdentifiable, IEnumerable<IOrderItem>
    {
        public IUser GetUser();
        public string GetDeliveryAddress();
        public Decimal GetProductsCost();
        public Decimal GetShippingCost();
        public Decimal GetTotalCost();
    }
}