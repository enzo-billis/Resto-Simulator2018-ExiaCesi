using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Shared
{
    public static class Parameters
    {
        public const int TABLES_BY_SQUARE = 6;
        public const int WAITER_BY_SQUARE = 1;
        public const int RANKCHIEF_NUMBER = 2;
        public const int MAP_NUMBER = 40;
        public static int SPEED = 1;

        private static Dictionary<string, int> options;

        public static Dictionary<string, int> Options { get => options; set => options = value; }
    }
}
