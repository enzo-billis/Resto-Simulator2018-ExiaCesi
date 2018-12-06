using Restaurant.Model.Salle.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Characters
{
    class Serveur : Position
    {
        public Serveur(int posX, int posY) : base(posX, posY)
        {
        }
        public Serveur() : base() { }
    }
}
