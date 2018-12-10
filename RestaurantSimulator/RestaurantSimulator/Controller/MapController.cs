using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller
{
    public class MapController
    {
        public static Semaphore MapSemaphore = new Semaphore(initialCount: Parameters.MAP_NUMBER, maximumCount: Parameters.MAP_NUMBER);

        public static Map GetMap()
        {
            MapSemaphore.WaitOne();
            return Map.Instance;
        }

        public static void ReleaseMap()
        {
            MapSemaphore.Release();
        }
    }
}
