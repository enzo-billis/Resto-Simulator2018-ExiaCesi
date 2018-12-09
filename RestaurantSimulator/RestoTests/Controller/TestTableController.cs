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

        [TestMethod]
        public void TestDriveGroupTable()
        {
            Table table = new Table(10, 64, 64);
            table.State = EquipmentState.InUse;
            RankChief rankChief = new RankChief(32, 32);
            rankChief.Squares[0].Tables.Add(table);

            TableController tableController = new TableController();
            tableController.DriveGroupTable(table, rankChief);
            Assert.IsNull(table.Group);
            Assert.AreEqual(32, rankChief.PosX);
            Assert.AreEqual(32, rankChief.PosY);

            Group group = new Group(128, 128);
            Assert.IsNotNull(group);
            table.Group = group;
            Assert.IsNotNull(table.Group);
            tableController.DriveGroupTable(table, rankChief);
            Assert.AreEqual(table.PosX - 32, rankChief.PosX);
            Assert.AreEqual(table.PosY, rankChief.PosY);
            Assert.AreEqual(table.PosX, group.PosX);
            Assert.AreEqual(table.PosY, group.PosY);
        }
    }
}
