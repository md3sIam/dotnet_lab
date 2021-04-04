using System;

namespace DomainModel
{
    public interface IProductReview : IIdentifiable
    {
        public IUser GetAuthor();
        public IProduct GetReviewedProduct();
        public string GetContent();
        public DateTime GetDateTimeCreated();
        public DateTime GetDateTimeUpdated();
    }
}