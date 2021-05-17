using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainModel
{
    public interface ICart : IEnumerable<ICartItem>, IIdentifiable
    {
        // Returns amount of this product
        public int AddProduct(IProduct product, int amount = 1);
        public int RemoveProduct(IProduct product, int amount = 1);
        public int GetTotalCartItems();
        public Decimal GetTotalCost();
        public IUser GetCartOwner();
    }
}