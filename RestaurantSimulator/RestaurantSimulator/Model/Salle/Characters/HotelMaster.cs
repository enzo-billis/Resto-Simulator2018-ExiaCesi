using Restaurant.Model.Salle.Movement;
using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Characters
{
    public class HotelMaster : Position
    {
        private List<RankChief> rankChiefs;

        public List<RankChief> RankChiefs
        {
            get => rankChiefs;
            set => rankChiefs = value;
        }

        public HotelMaster() : base ()
        {
            this.rankChiefs = new List<RankChief>();
            for (int i = 0; i < Parameters.RANKCHIEF_NUMBER; i++)
            {
                this.rankChiefs.Add(new RankChief());
            }
        }

        public HotelMaster(int posX, int posY) : base (posX, posY)
        {
            this.rankChiefs = new List<RankChief>();
            for (int i = 0; i < Parameters.RANKCHIEF_NUMBER; i++)
            {
                this.rankChiefs.Add(new RankChief());
            }
        }
    }
}
