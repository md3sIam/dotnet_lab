namespace DomainModel
{
    public interface ICartItem
    {
        public ICart GetParentCart();
        public IProduct GetProduct();
        public int GetAmount();
        public int IncreaseAmountOn(int value = 1);
        public int DecreaseAmountOn(int value = 1);
    }
}