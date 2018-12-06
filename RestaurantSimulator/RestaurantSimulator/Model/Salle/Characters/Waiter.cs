using Restaurant.Model.Salle.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Characters
{
    public class Waiter : Position
    {
        public Waiter(int posX, int posY) : base(posX, posY)
        {
        }
        public Waiter() : base() { }
    }
}
