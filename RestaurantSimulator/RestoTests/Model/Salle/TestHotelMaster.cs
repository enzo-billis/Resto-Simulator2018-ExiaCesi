using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Shared;

namespace RestoTests.Model.Salle
{
    [TestClass]
    public class TestHotelMaster
    {
        [TestMethod]
        public void TestHotelMasterConstruct()
        {
            HotelMaster BasicHotelMaster = new HotelMaster();
            Assert.AreEqual(0, BasicHotelMaster.PosX);
            Assert.AreEqual(0, BasicHotelMaster.PosY);
            Assert.AreEqual(Parameters.RANKCHIEF_NUMBER, BasicHotelMaster.RankChiefs.Count);

            HotelMaster PositionedHotelMaster = new HotelMaster(1, 11);
            Assert.AreEqual(1, PositionedHotelMaster.PosX);
            Assert.AreEqual(11, PositionedHotelMaster.PosY);
            Assert.AreEqual(Parameters.RANKCHIEF_NUMBER, PositionedHotelMaster.RankChiefs.Count);

            HotelMaster WrongPositioningHotelMaster = new HotelMaster(-6, -8);
            Assert.AreEqual(0, WrongPositioningHotelMaster.PosX);
            Assert.AreEqual(0, WrongPositioningHotelMaster.PosY);
            Assert.IsNotNull(BasicHotelMaster.RankChiefs);
            Assert.IsNotNull(PositionedHotelMaster.RankChiefs);
            Assert.AreEqual(Parameters.RANKCHIEF_NUMBER, WrongPositioningHotelMaster.RankChiefs.Count);

        }
    }
}
