using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    public class StockEquipment
    {
        private Dictionary<string, int> clean;
        private Dictionary<string, int> dirty;
        private static StockEquipment instance;
        private static readonly object padlock = new object();

        public Dictionary<string, int> Clean { get => clean; set => clean = value; }
        public Dictionary<string, int> Dirty { get => dirty; set => dirty = value; }

        public static StockEquipment Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StockEquipment();
                    }
                    return instance;
                }
            }
        }

        private StockEquipment()
        {
            this.clean = new Dictionary<string, int>();
            this.dirty = new Dictionary<string, int>();
        }

        
    }
}
