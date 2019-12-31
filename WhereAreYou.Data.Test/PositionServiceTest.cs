using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Interfaces;
using WhereAreYou.DAL.Repository;

namespace WhereAreYou.DAL.Test
{
    [TestClass]
    public class PositionServiceTest
    {
        private IPositionService positionService;
        private User testCurrentUser;
        private User testOtherUser;
        private List<Position> testData;

        public PositionServiceTest()
        {
            positionService = new PositionService();
            testCurrentUser = User.Create("TestUser", "");
            testOtherUser = User.Create("TestUser2", "");

            testData = new List<Position>();
            testData.Add(new Position(testCurrentUser, new Location(50.191200, 14.657949)));
            testData.Add(new Position(testOtherUser, new Location(50.196518, 14.675921)));
        }

        [TestMethod]
        public void CenterPointTest()
        {
            positionService.Compute(testData, testCurrentUser);
            var expected = new Location(50.19385934655583, 14.66693449958008);

            Assert.AreEqual(expected, positionService.CenterPoint);
        }

        [TestMethod]
        public void CurrentUserTest()
        {
            positionService.Compute(testData, testCurrentUser);

            Assert.AreEqual(testCurrentUser, positionService.CurrentUserPosition.User);
        }


        [TestMethod]
        public void UsersTest()
        {
            positionService.Compute(testData, testCurrentUser);

            var otherUsers = positionService.UsersPositions
                .Where(f => f.User
                .Equals(testOtherUser));

            Assert.AreEqual(positionService.UsersPositions.Count(), 1);
            Assert.IsTrue(otherUsers.Any());
        }
    }
}
