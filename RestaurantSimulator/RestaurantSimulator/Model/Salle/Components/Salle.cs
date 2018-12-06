using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    class Salle
    {
        private List<Square> squares;
        private HotelMaster hotelMaster;
        private static Commis commis;

        internal List<Square> Squares { get => squares; set => squares = value; }
        public HotelMaster HotelMaster { get => hotelMaster; set => hotelMaster = value; }
        public static Commis Commis { get => commis; set => commis = value; }
    }
}
