using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Salle.Characters;

namespace RestoTests.Model.Salle
{
    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void TestClientConstruct()
        {
            Client client = new Client();
            Assert.AreEqual(false, client.Entree);
            Assert.AreEqual(false, client.Plate);
            Assert.AreEqual(false, client.Dessert);
            Assert.IsNotNull(client.Strategy);
        }
    }
}
