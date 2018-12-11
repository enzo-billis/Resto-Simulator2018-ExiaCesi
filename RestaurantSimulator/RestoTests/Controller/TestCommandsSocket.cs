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
            //LoggerController.AppendLineToFile(Parameters.LOG_PATH, "Salle commands client started");
                KitchenCommandsController server = new KitchenCommandsController();
                server.InitSocketServerAsync();
                server.SocketListen();
                Console.WriteLine("SALUT ENZO");
                LoggerController.AppendLineToFile(Parameters.LOG_PATH, "Salle commands client started");

            SalleCommandsController client = new SalleCommandsController();
            client.InitClientSocketAsync();
            Group group = new Group();
            client.SendCommand(group);
           

            
            
        }
    }
}
