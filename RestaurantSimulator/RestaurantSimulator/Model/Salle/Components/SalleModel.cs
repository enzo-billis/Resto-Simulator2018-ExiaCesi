using Restaurant.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    public class SalleModel
    {
        private List<Square> squares;
        private HotelMaster hotelMaster;
        private static Commis commis;

        internal List<Square> Squares { get => squares; set => squares = value; }
        public HotelMaster HotelMaster { get => hotelMaster; set => hotelMaster = value; }
        public static Commis Commis { get => commis; set => commis = value; }
    }
}
