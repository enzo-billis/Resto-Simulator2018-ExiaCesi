using Restaurant.Model.Shared;
using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller
{
    public class WelcomeController
    {
        private HotelMaster hotelMaster;

        public WelcomeController(HotelMaster hotelMaster)
        {
            this.hotelMaster = hotelMaster;
        }

        public Client GenerateClient()
        {
            Client client;
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            switch (randomNumber)
            {
                case int rn when (rn <= 20):
                    client = HurriedClientFactory.Instance.CreateClient();
                    break;

                case int rn when (rn > 20 && rn < 80):
                    client = NormalClientFactory.Instance.CreateClient();
                    break;

                case int rn when (rn >= 80 && rn <= 100):
                    client = CoolClientFactory.Instance.CreateClient();
                    break;

                default:
                    client = NormalClientFactory.Instance.CreateClient();
                    break;
            }

            return client;
        }

        public Group CreateGroup(int clientNumber)
        {
            Group group = new Group();
            for (int i = 0; i < clientNumber; i++)
            {
                group.Clients.Add(this.GenerateClient());
            }
            return group;
        }
    }
}
