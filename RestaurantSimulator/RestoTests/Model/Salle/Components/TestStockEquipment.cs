using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Salle.Components;

namespace RestoTests.Model.Salle.Components
{
    /// <summary>
    /// Description résumée pour TestStockEquipment
    /// </summary>
    [TestClass]
    public class TestStockEquipment
    {
        [TestMethod]
        public void TestStockEquipmentInstance()
        {
            StockEquipment test = StockEquipment.Instance;
            Assert.IsNotNull(StockEquipment.Instance);
            Assert.AreEqual(test, StockEquipment.Instance);
        }
        [TestMethod]
        public void TestStockEquipmentConstructValues()
        {
            StockEquipment test = StockEquipment.Instance;
            Assert.IsNotNull(test.Clean);
            Assert.IsNotNull(test.Dirty);
        }
    }
}
