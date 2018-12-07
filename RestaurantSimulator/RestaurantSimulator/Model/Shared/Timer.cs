using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Shared
{
    public static class Timer
    {
        private static double time;
        public static double Time { get => time; set => time = value; }
    }
}
