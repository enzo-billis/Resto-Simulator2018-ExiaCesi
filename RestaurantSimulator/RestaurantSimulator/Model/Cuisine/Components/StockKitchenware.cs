using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Cuisine.Components
{
    public class StockKitchenware
    {
        private Dictionary<string, int> clean;
        private Dictionary<string, int> dirty;
        private static StockKitchenware instance = null;
        private static readonly object padlock = new object();

        public Dictionary<string, int> Clean { get => clean; set => clean = value; }
        public Dictionary<string, int> Dirty { get => dirty; set => dirty = value; }

        public static StockKitchenware Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StockKitchenware();
                    }
                    return instance;
                }
            }
        }

        private StockKitchenware()
        {
            this.clean = new Dictionary<string, int>();
            this.dirty = new Dictionary<string, int>();
        }
    }
}
