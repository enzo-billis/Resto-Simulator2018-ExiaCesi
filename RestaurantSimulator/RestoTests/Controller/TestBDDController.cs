using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Controller;
using System.Linq;
using RestaurantSimulator.Model.Shared;

namespace RestoTests.Controller
{
    [TestClass]
    public class TestBDDController
    {

        [TestMethod]
        public void TestConsumeIngredient()
        {
            var DB = BDDController.Instance.DB;
            var stockIngredient = from stock in DB.Stock
                                  where stock.id_Ingredient == 5
                                  select stock;

            var ingredientFromStock = stockIngredient.FirstOrDefault<Stock>();
            var ingredientFromIngredient = DB.Ingredient.Single(ing => ing.id_Ingredient == 5);
            int oldQuantity = (int)ingredientFromStock.quantité_Stock;
            BDDController.Instance.ConsumeIngredient(ingredientFromIngredient);

            Assert.AreEqual(oldQuantity - 1,
                DB.Stock.Single(ing => ing.id_Ingredient == 5).quantité_Stock);

            ingredientFromStock.quantité_Stock++;
            DB.SaveChanges();
        }
    }
}
