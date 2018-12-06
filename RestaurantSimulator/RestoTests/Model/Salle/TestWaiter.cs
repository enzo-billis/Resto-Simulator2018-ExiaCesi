using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Characters;

namespace RestoTests.Model.Salle
{
    [TestClass]
    public class TestServeur
    {
        [TestMethod]
        public void TestConstructServeur()
        {
            Waiter BasicServeur = new Waiter();
            Assert.AreEqual(0, BasicServeur.PosX);
            Assert.AreEqual(0, BasicServeur.PosY);
            Waiter PositionedServeur = new Waiter(1, 11);
            Assert.AreEqual(5, PositionedServeur.PosX);
            Assert.AreEqual(10, PositionedServeur.PosY);
            Waiter WrongPositioningServeur = new Waiter(-6, -8);
            Assert.AreEqual(0, WrongPositioningServeur.PosX);
            Assert.AreEqual(0, WrongPositioningServeur.PosY);
        }
    }
}
