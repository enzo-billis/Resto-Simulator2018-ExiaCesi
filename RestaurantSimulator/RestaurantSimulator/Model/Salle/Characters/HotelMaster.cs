using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Characters
{
    public class HotelMaster
    {
        private List<RankChief> rankChief;

        public List<RankChief> RankChief
        {
            get => rankChief;
            set => rankChief = value;
        }
    }
}
