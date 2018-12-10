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
        public void SendDirtyToolTest()
        {
            Dictionary<string, int> toTest;

            KitchenToolsController cleaner = new KitchenToolsController();

            cleaner.SendDirtyTools("spoon", 3);

            toTest = StockKitchenware.Instance.Dirty;

            Assert.AreEqual(toTest.ContainsKey("spoon"), true);

        }
        public void ReceiveCleanToolTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }
        public void VerifyStockTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }
    }
}
