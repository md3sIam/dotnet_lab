using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainModel
{
    public interface ICart : IEnumerable<ICartItem>, IIdentifiable
    {
        public int GetTotalCartItems();
        public Decimal GetTotalCost();
        public IUser GetCartOwner();
    }
}