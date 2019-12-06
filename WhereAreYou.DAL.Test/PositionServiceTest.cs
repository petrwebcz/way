using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Entity;
using WhereAreYou.DAL.Repository;

namespace WhereAreYou.DAL.Test
{
    [TestClass]
    public class PositionServiceTest
    {
        private IPositionService positionService;
        private IList<Location> testData;

        public PositionServiceTest()
        {
            testData = new List<Location>();
            testData.Add(new Location(50.191200, 14.657949));
            testData.Add(new Location(50.196518, 14.675921));

            positionService = new PositionService(testData);
        }

        [TestMethod]
        public void  GetCenterPointTest()
        {
            var expected = new Location(50.19385934655583, 14.66693449958008);
            var result = positionService.GetCenterPoint(testData);

            Assert.AreEqual(result, expected);
            Assert.AreEqual(result, expected);
        }

        public ILocation GetAdvertismentPointTest()
        {
            throw new NotImplementedException();
        }

       
    }
}
