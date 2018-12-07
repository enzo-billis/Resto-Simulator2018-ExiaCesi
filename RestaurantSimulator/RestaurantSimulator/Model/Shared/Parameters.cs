using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Shared
{
    public static class Parameters
    {

        private static Dictionary<string, int> options;

        public static Dictionary<string, int> Options { get => options; set => options = value; }
    }
}
