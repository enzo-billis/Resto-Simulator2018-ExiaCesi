using System.Collections.Generic;

namespace RestaurantSimulator.Model.Salle.Characters
{
    public class Client
    {
        private bool entree;
        private bool plate;
        private bool dessert;
        private Dictionary<string, int> strategy;

        public bool Entree { get => entree; set => entree = value; }
        public bool Plate { get => plate; set => plate = value; }
        public bool Dessert { get => dessert; set => dessert = value; }
        public Dictionary<string, int> Strategy { get => strategy; set => strategy = value; }

        public Client()
        {
            this.entree = false;
            this.plate = false;
            this.dessert = false;
            this.strategy = new Dictionary<string, int>();
        }
    }
}
