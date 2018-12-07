using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Model.Shared;


namespace RestoTests.Controller
{
    /// <summary>
    /// Description résumée pour TestTimeController
    /// </summary>
    [TestClass]
    public class TestTimeController
    {
        [TestMethod]
        public void TestSetGetTime()
        {
            GameTime testGameTime = new GameTime();
            TimeController.SetTime(testGameTime);
            Assert.AreEqual(testGameTime, Timer.Time);
            //
            // TODO: ajoutez ici la logique du test
            //
        }
    }
}
