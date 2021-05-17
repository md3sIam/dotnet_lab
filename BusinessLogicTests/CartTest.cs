using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using DomainModel;
using NUnit.Framework;
using FluentAssertions;
using Moq;

namespace BusinessLogicTests
{
    [TestFixture]
    public class CartTest
    {
        private Cart Cart;
        private List<IProduct> Products;
        private static int Id = 10;

        // just to try Moq
        private int UserId = 105;
        private string Username = "username";

        [SetUp]
        public void Setup()
        {
            var user_mock = new Mock<IUser>();
            user_mock.Setup(user => user.GetId()).Returns(UserId);
            user_mock.Setup(user => user.GetUsername()).Returns(Username);
            Cart = new Cart(Id, user_mock.Object);

            // preparing different data
            var product_names = new List<string> { "p1", "p2", "p3" };
            var costs = new List<Decimal> {1, 2, 3};
            Products = new List<IProduct>();
            for(int i = 0; i < product_names.Count; ++i)
                Products.Add(new Product(i, product_names[i], costs[i], new HashSet<IProductReview>()));
            
            foreach (IProduct product in Products)
                Cart.AddProduct(product);

            // first element is doubled in cart!
            Cart.AddProduct(Products[0]);
        }

        [Test]
        public void OwnerCheck_ShouldreturnRightOwner()
        {
            Cart.GetCartOwner().Should().Match<IUser>(user => user.GetId() == UserId && user.GetUsername() == Username);
        }

        [Test]
        public void ProductAddition_ShouldAdd()
        {
            Cart.GetTotalCartItems().Should().Be(Products.Count + 1);
            var en = Cart.GetEnumerator();
            en.MoveNext();
            for (int i = 0; i < Products.Count; ++i, en.MoveNext())
            {
                en.Current.Should().NotBeNull();
                en.Current.GetProduct().Should().Be(Products[i]);
            }
        }

        [Test]
        public void ProductRemove_ShouldRemove()
        {
            for (int i = 0; i < Products.Count; ++i)
            {
                Cart.RemoveProduct(Products[i]).Should().Match((int product_amount) =>
                    product_amount == (i == 0 ? 1 : 0)
                );
            }

            Cart.RemoveProduct(Products[0]).Should().Be(0);
        }

        [Test]
        public void ProductRemove_ShouldThrowOnRemovingNonExistent()
        {
            var non_existent_product = new Product(55, "qq", 0, new HashSet<IProductReview>());
            Cart.Invoking(cart => Cart.RemoveProduct(non_existent_product))
                .Should().Throw<InvalidOperationException>()
                .Where(e => e.Message.Contains("No such product"));
        }

        [Test]
        public void CalcSum_ShouldCalculateCorrectly()
        {
            decimal total_cost = Products.Aggregate(
                new Decimal(0), (sum, item_cost) => sum += item_cost.GetPrice());
            total_cost += Products[0].GetPrice();

            Cart.GetTotalCost().Should().Be(total_cost);
        }

    }
}