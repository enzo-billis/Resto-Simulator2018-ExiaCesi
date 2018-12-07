using RestaurantSimulator.Model.Salle.Characters;

namespace RestaurantSimulator.Model.Salle.Factory
{
    public class CoolClientFactory : AbstractClientFactory
    {
        private static CoolClientFactory instance;

        public static CoolClientFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new CoolClientFactory();
                return instance;
            }
        }

        private CoolClientFactory() { }
        public override Client CreateClient()
        {
            Client client = new Client();
            client.Strategy.Add("state", 2);
            client.Strategy.Add("dessert", 1);
            return client;
        }
    }
}
