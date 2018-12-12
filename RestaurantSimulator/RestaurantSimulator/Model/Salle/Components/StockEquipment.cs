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

            this.clean.Add("BreadBasket", 40);
            this.clean.Add("EntreePlate", 150);
            this.clean.Add("MainPlate", 150);
            this.clean.Add("DessertPlate", 150);
            this.clean.Add("fork", 150);
            this.clean.Add("knife", 150);
            this.clean.Add("soupSpoon", 150);
            this.clean.Add("glass", 150);
            this.clean.Add("tablecloth", 40);
            this.clean.Add("towel", 150);
            this.clean.Add("teaspoon", 150);
        }

        public bool SubstractEquipement(string equipement)
        {
            bool exist = this.clean.TryGetValue(equipement, out int eNumber);
            if ((exist) && (eNumber > 0))
            {
                this.clean[equipement] = eNumber - 1;
                return true;
            }
            return false;
        }
    }
}
