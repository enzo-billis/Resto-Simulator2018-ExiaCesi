using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Model.Shared;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Model.Salle.Characters;

namespace RestoTests.Controller
{
    [TestClass]
    public class TestWelcomeController
    {
        HotelMaster hotelMaster;
        WelcomeController welcomeController;

        [TestInitialize]
        public void SetUp()
        {
            hotelMaster = new HotelMaster(30, 40);
            welcomeController = new WelcomeController(hotelMaster);
        }

        [TestMethod]
        public void TestGenerateClient()
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < 100000; i++)
            {
                clients.Add(welcomeController.GenerateClient());
                Assert.IsNotNull(clients[i]);
                Assert.IsInstanceOfType(clients[i], typeof(Client));
            }
            Assert.IsTrue(clients.Exists(client => client.Strategy.ContainsValue(0)));
            Assert.IsTrue(clients.Exists(client => client.Strategy.ContainsValue(1)));
            Assert.IsTrue(clients.Exists(client => client.Strategy.ContainsValue(2)));
        }

        [TestMethod]
        public void TestCreateGroup()
        {
            Group group = welcomeController.CreateGroup(4);
            Assert.AreEqual(4, group.Clients.Count);
        }

        [TestMethod]
        public void TestCheckAvailableTables()
        {
            Group group = welcomeController.CreateGroup(7);
            Assert.IsTrue(welcomeController.CheckAvailableTables(group));
            group = welcomeController.CreateGroup(11);
            Assert.IsFalse(welcomeController.CheckAvailableTables(group));
        }

        [TestMethod]
        public void TestCallRankChief()
        {
            Group group = welcomeController.CreateGroup(5);
            hotelMaster.RankChiefs[0].Squares[0].Tables[4].Group = group;
            RankChief designatedRankChief = welcomeController.FindRankChief(group);
            Assert.AreEqual(hotelMaster.RankChiefs[0], designatedRankChief);
            welcomeController.CallRankChief(designatedRankChief);
            Assert.AreEqual(hotelMaster.PosX - 10, designatedRankChief.PosX);
            Console.WriteLine(hotelMaster.PosY);
            Console.WriteLine(designatedRankChief.PosY);
            Assert.AreEqual(hotelMaster.PosY, designatedRankChief.PosY);
        }
    }
}
