using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Cuisine.Components
{
    public class StockKitchenware
    {
        private Dictionary<string, Semaphore> stock;
       
        private static StockKitchenware instance = null;
        private static readonly object padlock = new object();

        public Dictionary<string, Semaphore> Stock { get => stock; set => stock = value; }
       

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
            this.stock = new Dictionary<string, Semaphore>();

            this.stock["four"] = new Semaphore(1, 1, "four");
            this.stock["poelle"] = new Semaphore(10, 10, "poelle");
            this.stock["plaque de cuisson"] = new Semaphore(5, 5, "plaqueCuisson");
            this.stock["planche a decouper"] = new Semaphore(2, 2, "plancheDecouper");
            this.stock["couteau"] = new Semaphore(5, 5, "couteau");
            this.stock["evier"] = new Semaphore(1, 1, "evier");
            this.stock["mixer"] = new Semaphore(1, 1, "mixer");
            this.stock["firgo"] = new Semaphore(10, 10, "firgo");
            this.stock["congelateur"] = new Semaphore(1, 1, "congelateur");
            this.stock["bol"] = new Semaphore(5, 5, "bol");
        }
    }
}
