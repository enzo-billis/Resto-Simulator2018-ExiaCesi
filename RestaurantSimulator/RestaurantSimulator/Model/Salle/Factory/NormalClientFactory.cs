using RestaurantSimulator.Model.Salle.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Factory
{
    public class NormalClientFactory : AbstractClientFactory
    {
        private static NormalClientFactory instance;

        public static NormalClientFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new NormalClientFactory();
                return instance;
            }
        }

        private NormalClientFactory() { }
        public override Client CreateClient()
        {
            Client client = new Client();
            client.Strategy.Add("state", 1);
            client.Strategy.Add("dessert", 0);
            return client;
        }
    }
}
