using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Controller.Kitchen;
using RestaurantSimulator.Model.Cuisine.Components;

namespace RestoTests.Controller
{
    /// <summary>
    /// Description résumée pour TestKitchenToolsController
    /// </summary>
    [TestClass]
    public class TestKitchenToolsController
    {
        [TestMethod]
        public void SendDirtyToolsTest()
        {
            StockKitchenware.Instance.Clean["spoon"] = 5;
            StockKitchenware.Instance.Dirty["spoon"] = 0;

            KitchenToolsController cleaner = new KitchenToolsController();

            cleaner.SendDirtyTools("spoon", 3);

            Assert.AreEqual(StockKitchenware.Instance.Clean["spoon"], 2);
            Assert.AreEqual(StockKitchenware.Instance.Dirty["spoon"], 3);

        }

        [TestMethod]
        public void ReceiveCleanToolsTest()
        {
            StockKitchenware.Instance.Clean["spoon"] = 5;
            StockKitchenware.Instance.Dirty["spoon"] = 0;

            KitchenToolsController cleaner = new KitchenToolsController();

            cleaner.SendDirtyTools("spoon", 3);
            cleaner.ReceiveCleanTools("spoon", 2);

            Assert.AreEqual(StockKitchenware.Instance.Clean["spoon"], 4);
            Assert.AreEqual(StockKitchenware.Instance.Dirty["spoon"], 1);
        }

        [TestMethod]
        public void VerifyStockTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }
    }
}
