using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Factory;

namespace RestoTests.Model.Salle
{
    [TestClass]
    public class TestFactory
    {
        [TestMethod]
        public void TestHurriedClientFactory()
        {
            HurriedClientFactory factory = HurriedClientFactory.Instance;
            Assert.IsNotNull(factory);
            Client client = factory.CreateClient();
            Assert.IsNotNull(client);
            client.Strategy.TryGetValue("state", out int value);
            Assert.AreEqual(0, value);
            client.Strategy.TryGetValue("dessert", out value);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void TestNormalClientFactory()
        {
            NormalClientFactory factory = NormalClientFactory.Instance;
            Assert.IsNotNull(factory);
            Client client = factory.CreateClient();
            Assert.IsNotNull(client);
            client.Strategy.TryGetValue("state", out int value);
            Assert.AreEqual(1, value);
            client.Strategy.TryGetValue("dessert", out value);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void TestCoolClientFactory()
        {
            CoolClientFactory factory = CoolClientFactory.Instance;
            Assert.IsNotNull(factory);
            Client client = factory.CreateClient();
            Assert.IsNotNull(client);
            client.Strategy.TryGetValue("state", out int value);
            Assert.AreEqual(2, value);
            client.Strategy.TryGetValue("dessert", out value);
            Assert.AreEqual(1, value);
        }
    }
}
