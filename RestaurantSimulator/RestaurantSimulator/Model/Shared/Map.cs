using System.Collections.Generic;

namespace RestaurantSimulator.Model.Shared
{
    public class Map
    {
        private static Map instance;
        private List<Recette> recipes;

        public static Map Instance
        {
            get
            {
                if (instance == null)
                    instance = new Map();
                return instance;
            }
        }

        private Map()
        {
            this.recipes = new List<Recette>();
        }

        public List<Recette> Recipes { get => recipes; set => recipes = value; }
    }
}
