using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Shared;

namespace RestoTests.Model.Shared
{
    [TestClass]
    public class TestMap
    {
        [TestMethod]
        public void TestMapSingleton()
        {
            Map map = Map.Instance;
            Assert.IsNotNull(map);
        }

        [TestMethod]
        public void TestMapConstruct()
        {
            Map map = Map.Instance;
            Assert.IsNotNull(map);
            Assert.IsNotNull(map.Recettes);
        }
    }
}
