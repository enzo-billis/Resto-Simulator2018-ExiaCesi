using RestaurantSimulator.Model.Salle.Characters;

namespace RestaurantSimulator.Model.Salle.Factory
{
    public class HurriedClientFactory : AbstractClientFactory
    {
        private static HurriedClientFactory instance;

        public static HurriedClientFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new HurriedClientFactory();
                return instance;
            }
        }

        private HurriedClientFactory() { }
        public override Client CreateClient()
        {
            Client client = new Client();
            client.Strategy.Add("state", 0);
            client.Strategy.Add("dessert", 0);
            return client;
        }
    }
}
