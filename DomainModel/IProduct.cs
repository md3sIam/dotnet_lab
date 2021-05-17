using System;
using System.Collections.Generic;

namespace DomainModel
{
    public interface IProduct : IIdentifiable, IEquatable<IProduct>
    {
        public string GetName();
        public Decimal GetPrice();
        public IEnumerable<IProductReview> GetReviews();
    }
}