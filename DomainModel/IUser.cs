namespace DomainModel
{
    public interface IUser : IIdentifiable
    {
        public string GetUsername();
    }
}