using System;
using System.Collections.Generic;
using BusinessLogic;
using DomainModel;
using NUnit.Framework;
using FluentAssertions;

namespace BusinessLogicTests
{
    [TestFixture]
    public class CartItemTest
    {
        private CartItem CartItem;

        [SetUp]
        public void Setup()
        {
            var cart = new Cart(1, new User(1, "user"));
            var prod = new Product(1, "prod", 2, new HashSet<IProductReview>());
            CartItem = new CartItem(prod, cart);
        }

        [Test]
        public void ShouldIncrease()
        {
            for (int i = 2; i < 10000; ++i)
            {
                CartItem.IncreaseAmountOn(1);
                CartItem.GetAmount().Should().Be(i);
            }
        }

        [Test]
        public void ShouldDecrease()
        {
            CartItem.IncreaseAmountOn(5);
            for (int i = CartItem.GetAmount(); i > 1; --i)
            {
                CartItem.DecreaseAmountOn(1);
                CartItem.GetAmount().Should().Be(i - 1);
            }
        }

        [Test]
        public void ShouldThrowOnDecreasingToLessThanOne()
        {
            for(int i = 1; i < 10; ++i)
                CartItem.Invoking(item => item.DecreaseAmountOn(1))
                    .Should().Throw<InvalidOperationException>()
                    .Where(e => e.Message.Contains("less than 1"));
        }
    }
}