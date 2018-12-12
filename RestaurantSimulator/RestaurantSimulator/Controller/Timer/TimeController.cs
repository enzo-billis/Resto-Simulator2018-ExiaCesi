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
        private static int temps, lastSec, currentSec = 0;

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
            

            lastSec = currentSec;
            currentSec = Timer.Time.TotalGameTime.Seconds;
                if (lastSec != currentSec)
            {
                temps += 1 * Parameters.SPEED;
            }
            return temps;
        }

        public static GameTime Time { get => time; set => time = value; }
    }
}
