using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Model.Shared;

namespace RestoTests.Model.Salle
{
    [TestClass]
    public class TestGroup
    {
        [TestMethod]
        public void TestGroupConstruct()
        {
            Group BasicGroup = new Group();
            Assert.AreEqual(0, BasicGroup.PosX);
            Assert.AreEqual(0, BasicGroup.PosY);
            Assert.IsNotNull(BasicGroup.Clients);
            Assert.AreEqual(1, BasicGroup.ID);
            BasicGroup.Move(2, 3);
            Assert.AreEqual(2, BasicGroup.PosX);
            Assert.AreEqual(3, BasicGroup.PosY);

            Group PositionedGroup = new Group(1, 11);
            Assert.AreEqual(1, PositionedGroup.PosX);
            Assert.AreEqual(11, PositionedGroup.PosY);
            Assert.IsNotNull(PositionedGroup.Clients);
            Assert.AreEqual(2, PositionedGroup.ID);
            PositionedGroup.Move(2, 3);
            Assert.AreEqual(2, PositionedGroup.PosX);
            Assert.AreEqual(3, PositionedGroup.PosY);

            Group WrongPositioningGroup = new Group(-6, -8);
            Assert.AreEqual(0, WrongPositioningGroup.PosX);
            Assert.AreEqual(0, WrongPositioningGroup.PosY);
            Assert.IsNotNull(WrongPositioningGroup.Clients);
            Assert.AreEqual(3, WrongPositioningGroup.ID);
            WrongPositioningGroup.Move(2, 3);
            Assert.AreEqual(2, WrongPositioningGroup.PosX);
            Assert.AreEqual(3, WrongPositioningGroup.PosY);
        }
    }
}
