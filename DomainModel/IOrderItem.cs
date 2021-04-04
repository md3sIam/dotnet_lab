namespace DomainModel
{
    public interface IOrderItem
    {
        public ICart GetParentOrder();
        public IProduct GetProduct();
        public int GetAmount();
    }
}