using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantSimulator.Controller.Kitchen;
using RestaurantSimulator.Controller.Salle;
using RestaurantSimulator.Model.Salle.Components;

namespace RestaurantSimulator.Model.Shared
{
    public class RestaurantLauncher
    {
        private List<SalleModel> salles;
        private SalleController salleController;
        private KitchenController kitchenController;
        private Game1 game;
        public int speed = 16;
        public List<SalleModel> Salles { get => salles; set => salles = value; }
        public Game1 Game { get => game; set => game = value; }

        public RestaurantLauncher()
        {
            salles = new List<SalleModel>();
            salles.Add(new SalleModel());
            salleController = new SalleController();
            kitchenController = new KitchenController();
            Thread kitchenCommands = new Thread(LaunchKitchenCommands);
            Thread salleCommands = new Thread(LaunchSalleCommandsAsync);
            game = new Game1();
            game.SalleModel = salles[0];
            kitchenCommands.Start();
            salleCommands.Start();

        }

        private void LaunchKitchenCommands()
        {
            kitchenController.kitchenCommandsController.InitSocketServerAsync();
            kitchenController.kitchenCommandsController.SocketListen();
        }

        private void LaunchSalleCommandsAsync()
        {
            Thread.Sleep(5000);
            salleController.SalleCommandsController.InitClientSocketAsync();
            salleController.SalleCommandsController.SocketConnect();
            salleController.SalleCommandsController.SendCommand(new Restaurant.Model.Shared.Group());
        }
    }
}
