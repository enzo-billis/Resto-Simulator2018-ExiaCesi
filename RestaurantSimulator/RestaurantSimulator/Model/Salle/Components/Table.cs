using Restaurant.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    class Table
    {
        private int NbPlaces;
        private Group Group;
        private bool Entree;
        private bool Plate;
        private bool Dessert;

        public int NbPlaces1 { get => NbPlaces; set => NbPlaces = value; }
        public Group Group1 { get => Group; set => Group = value; }
        public bool Entree1 { get => Entree; set => Entree = value; }
        public bool Plate1 { get => Plate; set => Plate = value; }
        public bool Dessert1 { get => Dessert; set => Dessert = value; }
    }
}
