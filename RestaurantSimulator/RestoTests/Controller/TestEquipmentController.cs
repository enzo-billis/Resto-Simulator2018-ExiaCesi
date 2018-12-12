using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Salle.Components;
using RestaurantSimulator.Controller.Salle;


namespace RestoTests.Controller
{
    /// <summary>
    /// Description résumée pour TestEquipmentController
    /// </summary>
    [TestClass]
    public class TestEquipmentController
    {

        [TestMethod]
        public void TestdefineAsDirty()
        {
            StockEquipment.Instance.InUse["towel"] = 1;
            EquipmentController.defineAsDirty("towel");

            Assert.AreEqual(1, StockEquipment.Instance.Dirty["towel"]);
            Assert.AreEqual(0, StockEquipment.Instance.InUse["towel"]);

            StockEquipment.Instance.InUse["teaspoon"] = 5;
            EquipmentController.defineAsDirty("teaspoon");
            EquipmentController.defineAsDirty("teaspoon");

            Assert.AreEqual(2, StockEquipment.Instance.Dirty["teaspoon"]);
            Assert.AreEqual(3, StockEquipment.Instance.InUse["teaspoon"]);
        }

        [TestMethod]
        public void TestdefineAsInUse()
        {
            
            Assert.IsTrue(EquipmentController.defineAsInUse("towel"));

            Assert.AreEqual(1, StockEquipment.Instance.InUse["towel"]);
            Assert.AreEqual(149, StockEquipment.Instance.Clean["towel"]);

            
            EquipmentController.defineAsInUse("teaspoon");
            EquipmentController.defineAsInUse("teaspoon");

            Assert.AreEqual(2, StockEquipment.Instance.InUse["teaspoon"]);
            Assert.AreEqual(148, StockEquipment.Instance.Clean["teaspoon"]);
        }

        [TestMethod]
        public void TestdefineAsClean()
        {
            StockEquipment.Instance.Washing["towel"] = 1;
            Assert.IsTrue(EquipmentController.defineAsClean("towel"));

            Assert.AreEqual(0, StockEquipment.Instance.Washing["towel"]);
            Assert.AreEqual(151, StockEquipment.Instance.Clean["towel"]);

            StockEquipment.Instance.Washing["teaspoon"] = 5;
            EquipmentController.defineAsClean("teaspoon");
            EquipmentController.defineAsClean("teaspoon");

            Assert.AreEqual(3, StockEquipment.Instance.Washing["teaspoon"]);
            Assert.AreEqual(152, StockEquipment.Instance.Clean["teaspoon"]);
        }

        [TestMethod]
        public void TestdefineAsWashing()
        {
            StockEquipment.Instance.Dirty["towel"] = 1;
            Assert.IsTrue(EquipmentController.defineAsWashing("towel"));

            Assert.AreEqual(1, StockEquipment.Instance.Washing["towel"]);
            Assert.AreEqual(0, StockEquipment.Instance.Dirty["towel"]);

            StockEquipment.Instance.Dirty["teaspoon"] = 5;
            EquipmentController.defineAsWashing("teaspoon");
            EquipmentController.defineAsWashing("teaspoon");

            Assert.AreEqual(2, StockEquipment.Instance.Washing["teaspoon"]);
            Assert.AreEqual(3, StockEquipment.Instance.Dirty["teaspoon"]);
        }
    }
}
