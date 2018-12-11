using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Cuisine.Components;

namespace RestoTests.Model.Cuisine.Components
{
   
    [TestClass]
    public class TestStockKitchenware
    {
        [TestMethod]
        public void TestStockKitchenwareInstance()
        {
            StockKitchenware test = StockKitchenware.Instance;
            Assert.IsNotNull(StockKitchenware.Instance);
            Assert.AreEqual(test,StockKitchenware.Instance);
        }

        [TestMethod]
        public void TestStockKitchenwareConstructValues()
        {
            StockKitchenware test = StockKitchenware.Instance;
            Assert.IsNotNull(test.Stock);
        }
    }
}
