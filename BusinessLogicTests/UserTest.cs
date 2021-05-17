using NUnit.Framework;
using BusinessLogic;
using DomainModel;

namespace BusinessLogicTests
{
    [TestFixture]
    public class UserTest
    {
        private BusinessLogic.User User;
        private static int UserId = 10;
        private static string Username = "username";

        [SetUp]
        public void Setup()
        {
            User = new BusinessLogic.User(UserId, Username);
        }

        [Test]
        public void IsUserCorrectedSetup()
        {
            Assert.AreEqual(User.GetId(), UserId);
            Assert.AreEqual(User.GetUsername(), Username);
        }
    }
}