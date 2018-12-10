using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Components;
using RestaurantSimulator.Model.Shared;

namespace RestoTests.Model.Cuisine.Components
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void TestSquareConstruct()
        {
            HotelMaster hotelMaster = new HotelMaster();
            Assert.IsNotNull(hotelMaster.RankChiefs[0].Squares[0].Tables);
            Assert.IsNotNull(hotelMaster.RankChiefs[0].Squares[0].Waiters);
            Assert.AreEqual(Parameters.TABLES_BY_SQUARE, hotelMaster.RankChiefs[0].Squares[0].Tables.Count);
            Assert.AreEqual(Parameters.WAITER_BY_SQUARE, hotelMaster.RankChiefs[0].Squares[0].Waiters.Count);
        }
    }
}
