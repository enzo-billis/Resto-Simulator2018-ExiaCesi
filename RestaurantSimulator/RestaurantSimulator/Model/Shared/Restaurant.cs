using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSimulator.Model.Salle.Components;

namespace RestaurantSimulator.Model.Shared
{
    public class Restaurant
    {
        private List<SalleModel> Salles;
        //private SalleController salleController;
        //private KitchenController kitchenController;
        private Game1 game;

        public List<SalleModel> Salles1 { get => Salles; set => Salles = value; }
        public Game1 Game { get => game; set => game = value; }
    }
}
