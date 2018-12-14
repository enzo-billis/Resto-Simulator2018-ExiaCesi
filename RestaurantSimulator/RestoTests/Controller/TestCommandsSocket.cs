using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Model.Shared;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Controller.Kitchen;
using RestaurantSimulator.Controller.Salle;
using RestaurantSimulator.Model.Shared;

namespace RestoTests.Controller
{
    [TestClass]
    public class TestCommandsSocket
    {
        [TestMethod]
        public async Task TestInitConnection()
        {
            Assert.IsFalse(Parameters.KITCHEN_SERVER_STARTED);
            KitchenCommandsController server = new KitchenCommandsController();
            server.InitSocketServerAsync();
            Assert.IsTrue(Parameters.KITCHEN_SERVER_STARTED);

            Assert.IsFalse(Parameters.SALLE_CLIENT_STARTED);
            SalleCommandsController client = new SalleCommandsController();
            client.InitClientSocketAsync();
            Assert.IsTrue(Parameters.SALLE_CLIENT_STARTED);




        }
    }
}
