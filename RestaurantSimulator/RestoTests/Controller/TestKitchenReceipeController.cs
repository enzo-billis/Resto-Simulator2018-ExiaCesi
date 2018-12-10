﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Shared;
using RestaurantSimulator.Controller;
using System.Linq;
using RestaurantSimulator.Controller.Kitchen;

namespace RestoTests.Controller
{
    /// <summary>
    /// Description résumée pour TestKitchenReceipeController
    /// </summary>
    [TestClass]
    public class TestKitchenReceipeController
    {
        [TestMethod]
        public void CookCallbackTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }
        [TestMethod]
        public void GetReceipeTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }
        [TestMethod]
        public void VerifyDispoToolTest()
        {
            

            Recette receipe = BDDController.Instance.DB.Recette.SingleOrDefault(r => r.id_recette == 1);
            Assert.IsTrue(KitchenReceipeController.VerifyDispoTool(receipe));

            receipe = BDDController.Instance.DB.Recette.SingleOrDefault(r => r.id_recette == 2);
            Assert.IsTrue(KitchenReceipeController.VerifyDispoTool(receipe));

            receipe = BDDController.Instance.DB.Recette.SingleOrDefault(r => r.id_recette == 0);
            Assert.IsTrue(KitchenReceipeController.VerifyDispoTool(receipe));
        }
        [TestMethod]
        public void FreeSemaphReceipeTest()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }
    }
}
