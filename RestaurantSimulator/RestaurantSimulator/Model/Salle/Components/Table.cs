using Restaurant.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    public class Table
    {
        private int nbPlaces;
        private Group group;
        private bool entree = false;
        private bool plate = false;
        private bool dessert = false;

        public Table(int nbPlaces)
        {
            this.nbPlaces = nbPlaces;
        }

        public int NbPlaces { get => nbPlaces; set => nbPlaces = value; }
        public Group Group { get => group; set => group = value; }
        public bool Entree { get => entree; set => entree = value; }
        public bool Plate { get => plate; set => plate = value; }
        public bool Dessert { get => dessert; set => dessert = value; }
    }
}
