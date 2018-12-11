using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RestaurantSimulator.Model.Shared
{
    public static class Timer
    {
        private static GameTime time;
        public static GameTime Time { get => time; set => time = value; }
    }
}
