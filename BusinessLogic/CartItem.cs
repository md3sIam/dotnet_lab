using System;
using DomainModel;

namespace BusinessLogic
{
    public class CartItem : ICartItem
    {
        public CartItem(IProduct product, ICart parent_cart, int amount = 1)
        {
            Product = product;
            ParentCart = parent_cart;
            Amount = amount;
        }
        
        public ICart GetParentCart()
        {
            return ParentCart;
        }

        public IProduct GetProduct()
        {
            return Product;
        }

        public int GetAmount()
        {
            return Amount;
        }

        public int IncreaseAmountOn(int value = 1)
        {
            return Amount += value;
        }

        public int DecreaseAmountOn(int value)
        {
            Amount -= value;
            if (Amount < 1)
                throw new InvalidOperationException("Amount of products in CartItem cannot be less than 1");
            return Amount;
        }

        private readonly ICart ParentCart;
        private readonly IProduct Product;
        private int Amount;
    }
}