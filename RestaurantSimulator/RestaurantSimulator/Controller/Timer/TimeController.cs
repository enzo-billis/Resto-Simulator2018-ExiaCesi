using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSimulator.Model.Shared;
using Microsoft.Xna.Framework;

namespace RestaurantSimulator.Controller
{
    public class TimeController
    {
        private static GameTime time;
        public TimeController() {}

        public static void SetTime(GameTime timeParam)
        {
            Timer.Time = timeParam;
        }

        public static GameTime Time { get => time; set => time = value; }
    }
}
