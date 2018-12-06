using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Characters
{
    class Client
    {
        private Recipe Entree;
        private Recipe Plate;
        private Recipe Dessert;

        public Recipe Entree1 { get => Entree; set => Entree = value; }
        public Recipe Plate1 { get => Plate; set => Plate = value; }
        public Recipe Dessert1 { get => Dessert; set => Dessert = value; }
    }
}
