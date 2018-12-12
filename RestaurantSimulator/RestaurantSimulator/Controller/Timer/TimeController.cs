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

        public static GameTime GetGameTime()
        {
            return Timer.Time;
        }

        public static int GetTimer()
        {
            int multiplier = 10 * Parameters.SPEED;
            return Convert.ToInt32(Timer.Time.TotalGameTime.TotalSeconds) * multiplier;
        }

        public static GameTime Time { get => time; set => time = value; }
    }
}
