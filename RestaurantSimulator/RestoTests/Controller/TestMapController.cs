using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Model.Shared;

namespace RestoTests.Controller
{
    [TestClass]
    public class TestMapController
    {
        [TestMethod]
        public void TestGetMap()
        {
            Map map = MapController.GetMap();
            Assert.IsNotNull(map);
            Assert.IsInstanceOfType(map, typeof(Map));
        }

        [TestMethod]
        public void TestReleaseMap()
        {
            Map map = MapController.GetMap();
            Assert.IsNotNull(map);
            Assert.IsInstanceOfType(map, typeof(Map));

            MapController.ReleaseMap();
        }

        [TestMethod]
        public void TestUpdateMap()
        {
            MapController.UpdateMap();
        }
    }
}
