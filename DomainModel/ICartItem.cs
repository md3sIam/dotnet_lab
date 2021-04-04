namespace DomainModel
{
    public interface ICartItem
    {
        public ICart GetParentCart();
        public IProduct GetProduct();
        public int GetAmount();
    }
}