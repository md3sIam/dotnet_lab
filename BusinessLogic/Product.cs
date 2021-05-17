using System;
using System.Collections.Generic;
using DomainModel;

namespace BusinessLogic
{
    public class Product : DomainModel.IProduct
    {
        public Product(int id, string name, decimal price, HashSet<IProductReview> reviews)
        {
            Id = id;
            Name = name;
            Price = price;
            Reviews = reviews;
        }

        public bool Equals(IProduct? other)
        {
            if (other == null)
                return false;
            // same products have the same id
            return other.GetId() == Id;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public IEnumerable<IProductReview> GetReviews()
        {
            return Reviews;
        }
        
        private readonly int Id;
        private readonly string Name;
        private readonly decimal Price;
        private readonly HashSet<IProductReview> Reviews;
    }
}