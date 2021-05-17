using System;
using System.Collections;
using System.Collections.Generic;
using DomainModel;

namespace BusinessLogic
{
    public class Cart : ICart
    {
        public Cart(int id, IUser owner)
        {
            Id = id;
            Owner = owner;
            CartItems = new List<ICartItem>();
            CartProductIds = new HashSet<int>();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ICartItem> GetEnumerator()
        {
            foreach (var item in CartItems)
                yield return item;
        }

        public int GetId()
        {
            return Id;
        }

        public int AddProduct(IProduct product, int amount = 1)
        {
            bool exist = CartProductIds.Contains(product.GetId());
            if (exist)
            {
                ICartItem item = CartItems.Find(cartItem => cartItem.GetProduct().Equals(product));
                if (item == null)
                    throw new InvalidOperationException("Item exist in HashSet but not in CartItems");
                return item.IncreaseAmountOn(amount);
            }
            
            CartProductIds.Add(product.GetId());
            CartItems.Add(new CartItem(product, this, amount));
            return amount;
        }

        public int RemoveProduct(IProduct product, int amount = 1)
        {
            if (!CartProductIds.Contains(product.GetId()))
                throw new InvalidOperationException("No such product in a cart");

            ICartItem item = CartItems.Find(cartItem => cartItem.GetProduct().Equals(product));
            if (item == null)
                throw new InvalidOperationException("Item exist in HashSet but not in CartItems");

            if (item.GetAmount() != amount)
                return item.DecreaseAmountOn(amount);
            
            // here item should be deleted
            CartProductIds.Remove(product.GetId());
            CartItems.RemoveAll(cartItem => cartItem.GetProduct().Equals(product));
            return 0;
        }

        public int GetTotalCartItems()
        {
            int amount = 0;
            foreach (ICartItem item in CartItems)
                amount += item.GetAmount();
            return amount;
        }

        public decimal GetTotalCost()
        {
            decimal total_cost = 0;
            foreach (ICartItem item in CartItems)
                total_cost += item.GetProduct().GetPrice() * item.GetAmount();
            return total_cost;
        }

        public IUser GetCartOwner()
        {
            return Owner;
        }

        private readonly int Id;
        private readonly IUser Owner;
        private List<ICartItem> CartItems;
        // only to easy check if product already in a cart (faster than searching in a list)
        private HashSet<int> CartProductIds;
    }
}