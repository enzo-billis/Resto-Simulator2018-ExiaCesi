using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller
{
    public class BDDController
    {
        private static BDDController instance;

        private BDDController()
        {
            this.InitConnection();
        }

        public static BDDController Instance
        {
            get
            {
                if (instance == null)
                    instance = new BDDController();
                return instance;
            }
        }

        public BDDRestaurant DB;

        public void InitConnection()
        {
            DB = new BDDRestaurant();
        }

        public void CloseConnection()
        {
            DB.Dispose();
        }

        public void ConsumeIngredient(Ingredient ingredient)
        {
            if(ingredient != null)
            {
                if(DB.Ingredient.Find(ingredient.id_Ingredient) != null)
                {
                    var result = DB.Stock.SingleOrDefault(stock => stock.id_Ingredient == ingredient.id_Ingredient);
                    if (result.quantité_Stock > 0)
                    {
                        result.quantité_Stock--;
                    }
                    DB.SaveChanges();
                }
            }
        }
    }
}
