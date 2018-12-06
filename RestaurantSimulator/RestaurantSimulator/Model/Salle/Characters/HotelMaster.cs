using Restaurant.Model.Salle.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Characters
{
    public class HotelMaster : Position
    {
        private List<RankChief> rankChief;

        public List<RankChief> RankChief
        {
            get => rankChief;
            set => rankChief = value;
        }

        public HotelMaster() : base ()
        {
            this.rankChief = new List<RankChief>();
        }

        public HotelMaster(int posX, int posY) : base (posX, posY)
        {
            this.rankChief = new List<RankChief>();
        }
    }
}
