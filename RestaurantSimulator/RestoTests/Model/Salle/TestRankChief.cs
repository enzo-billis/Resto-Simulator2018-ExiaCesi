using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Salle.Characters;

namespace RestoTests.Model.Salle
{
    [TestClass]
    public class TestRankChief
    {
        [TestMethod]
        public void TestMethod1()
        {
            RankChief BasicRankChief = new RankChief();
            Assert.AreEqual(0, BasicRankChief.PosX);
            Assert.AreEqual(0, BasicRankChief.PosY);
            RankChief PositionedRankChief = new RankChief(1, 11);
            Assert.AreEqual(1, PositionedRankChief.PosX);
            Assert.AreEqual(11, PositionedRankChief.PosY);
            RankChief WrongPositioningRankChief = new RankChief(-6, -8);
            Assert.AreEqual(0, WrongPositioningRankChief.PosX);
            Assert.AreEqual(0, WrongPositioningRankChief.PosY);
            Assert.IsNotNull(BasicRankChief.Squares);
            Assert.IsNotNull(PositionedRankChief.Squares);
        }
    }
}
