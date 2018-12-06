using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Movement
{
    public interface IMove
    {
        void Move(int posX, int posY);
    }
}
