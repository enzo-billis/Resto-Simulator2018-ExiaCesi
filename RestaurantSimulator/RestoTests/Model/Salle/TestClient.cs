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
            Assert.IsNull(client.Entree);
            Assert.IsNull(client.Plate);
            Assert.IsNull(client.Dessert);
            Assert.IsNotNull(client.Strategy);
        }
    }
}
