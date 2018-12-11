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
        public void senddirtytools(string kitchenware, int quantity)
        {
        //    stockkitchenware.instance.dirty[kitchenware] += quantity;
        //    stockkitchenware.instance.clean[kitchenware] -= quantity;
        }

        public void SetInUseTool(string kitchenware)
           {
            StockKitchenware.Instance.Stock[kitchenware].WaitOne();
           }

        public void ReceiveCleanTools(string kitchenware, int quantity)
        {
            //StockKitchenware.Instance.Dirty[kitchenware] -= quantity;
            //StockKitchenware.Instance.Clean[kitchenware] += quantity;
        }

        //public bool VerifyStock(string kitchenware, int quantity)
        //{
        //    int stockQuantity = StockKitchenware.Instance.Clean[kitchenware];
        //    return (stockQuantity >= quantity && quantity > 0) ? true : false;
        //}
    }
}
