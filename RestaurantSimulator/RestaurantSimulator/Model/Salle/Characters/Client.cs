using RestaurantSimulator.Model.Shared;
using System.Collections.Generic;

namespace RestaurantSimulator.Model.Salle.Characters
{
    public class Client
    {
        private Recipe entree;
        private Recipe plate;
        private Recipe dessert;
        private Dictionary<string, int> strategy;

        public Recipe Entree { get => entree; set => entree = value; }
        public Recipe Plate { get => plate; set => plate = value; }
        public Recipe Dessert { get => dessert; set => dessert = value; }
        public Dictionary<string, int> Strategy { get => strategy; set => strategy = value; }

        public Client()
        {
            this.entree = null;
            this.plate = null;
            this.dessert = null;
            this.strategy = new Dictionary<string, int>();
        }
    }
}
