using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Model.Shared;
using RestaurantSimulator.Model.Salle.Observer;

namespace RestoTests.Model.Salle
{
    [TestClass]
    public class TestDPObserver
    {
        Subject subject = new Subject();

        private class Observer : IObserver
        {
            public Group group;
            public void Update(Group group)
            {
                if (group != null)
                    this.group = group;
            }
        }

        [TestMethod]
        public void TestSubscribe()
        {
            Assert.AreEqual(0, subject.Count);
            Observer observer = new Observer();
            Assert.IsNull(observer.group);
            this.subject.Subscribe(observer);
            Assert.AreEqual(1, subject.Count);
        }

        [TestMethod]
        public void TestUnsubscribe()
        {
            Observer observer = new Observer();
            this.subject.Subscribe(observer);
            Assert.IsNull(observer.group);
            Assert.AreEqual(1, this.subject.Count);
            this.subject.Unsubscribe(observer);
            Assert.AreEqual(0, this.subject.Count);
        }

        [TestMethod]
        public void TestNotify()
        {
            Observer observer = new Observer();
            this.subject.Subscribe(observer);
            Assert.AreEqual(1, this.subject.Count);
            Group group = new Group();
            Assert.IsNull(observer.group);
            this.subject.Notify(group);
            Assert.IsNotNull(observer.group);
        }
    }
}
