using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RestaurantSimulator.Model.Cuisine
{
    class KitchenPools
    {
        public static List<Thread> ThreadPoolCooker;
        public static List<Thread> ThreadPoolDisher;
    }
}
