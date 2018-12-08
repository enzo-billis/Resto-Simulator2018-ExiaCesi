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
        private HotelMaster hotelMaster;
        private static Commis commis;

        public SalleModel()
        {
            hotelMaster = new HotelMaster();
            commis = new Commis();
        }

        public HotelMaster HotelMaster { get => hotelMaster; set => hotelMaster = value; }
        public static Commis Commis { get => commis; set => commis = value; }
    }
}
