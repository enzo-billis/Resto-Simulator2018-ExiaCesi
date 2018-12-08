using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Square square = new Square();
            Assert.IsNotNull(square.Tables);
            Assert.IsNotNull(square.Waiters);
            Assert.AreEqual(Parameters.TABLES_BY_SQUARE, square.Tables.Count);
            Assert.AreEqual(Parameters.WAITER_BY_SQUARE, square.Waiters.Count);
        }
    }
}
