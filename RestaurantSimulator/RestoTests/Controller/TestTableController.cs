using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Model.Salle.Components;
using Restaurant.Model.Shared;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Components;

namespace RestoTests.Controller
{
    [TestClass]
    public class TestTableController
    {
        [TestMethod]
        public void TestAttributionTableGroup()
        {
            HotelMaster hotelMaster = new HotelMaster();
            WelcomeController welcomeController = new WelcomeController(hotelMaster);
            Group group = welcomeController.CreateGroup(5);
            TableController tableController = new TableController();
            Table table = tableController.OptimizedFindTable(hotelMaster.RankChiefs[0].Squares[0].Tables, group.Clients.Count);
            if (table == null)
                table = tableController.OptimizedFindTable(hotelMaster.RankChiefs[1].Squares[0].Tables, group.Clients.Count);
            Assert.IsNotNull(table);
            bool success = tableController.AttributionTableGroup(group, table);
            Assert.IsTrue(success);
            Assert.AreEqual(EquipmentState.InUse, table.State);
            Assert.AreEqual(GroupState.Ordering, group.State);
        }

        [TestMethod]
        public void TestCleanTable()
        {
            Table table = new Table(10);
            Assert.AreEqual(EquipmentState.Available, table.State);

            table.State = EquipmentState.InUse;
            TableController.CleanTable(table);
            Assert.AreEqual(EquipmentState.InUse, table.State);

            table.State = EquipmentState.Dirty;
            TableController.CleanTable(table);
            Assert.AreEqual(EquipmentState.Available, table.State);
        }
    }
}
