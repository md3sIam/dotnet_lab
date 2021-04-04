using System;
using System.Collections.Generic;

namespace DomainModel
{
    public interface IProduct : IIdentifiable
    {
        public string GetName();
        public Decimal GetPrice();
        public IEnumerable<IProductReview> GetReviews();
    }
}