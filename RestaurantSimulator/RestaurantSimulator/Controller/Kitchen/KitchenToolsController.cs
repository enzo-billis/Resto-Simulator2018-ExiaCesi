using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantSimulator.Model.Cuisine.Components;

namespace RestaurantSimulator.Controller.Kitchen
{
    public class KitchenToolsController
    {
        public void SendDirtyTools(string kitchenware, int quantity)
        {
            StockKitchenware.Instance.Dirty[kitchenware] += quantity;
            StockKitchenware.Instance.Clean[kitchenware] -= quantity;
        }

        public void ReceiveCleanTools(string kitchenware, int quantity)
        {
            StockKitchenware.Instance.Dirty[kitchenware] -= quantity;
            StockKitchenware.Instance.Clean[kitchenware] += quantity;
        }

        public bool VerifyStock(string kitchenware, int quantity)
        {
            int stockQuantity = StockKitchenware.Instance.Clean[kitchenware];
            return (stockQuantity >= quantity && quantity > 0) ? true : false;
        }
    }
}
