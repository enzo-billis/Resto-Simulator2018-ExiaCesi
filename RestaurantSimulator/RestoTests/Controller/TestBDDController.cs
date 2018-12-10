﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Controller;
using System.Linq;
using RestaurantSimulator.Model.Shared;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestGetRecettes()
        {
            var recettes = BDDController.Instance.GetRecettes();
            Assert.IsNotNull(recettes);
            Assert.IsInstanceOfType(recettes, typeof(List<Recette>));
        }

        [TestMethod]
        public void TestAddIngredient()
        {
            var DB = BDDController.Instance.DB;
            var ingredient = DB.Ingredient.Single(ing => ing.id_Ingredient == 5);
            var stockIngredient = DB.Stock.Single(ing => ing.id_Ingredient == 5);
            int oldStock = (int)stockIngredient.quantité_Stock;
            Assert.IsNotNull(stockIngredient);
            BDDController.Instance.AddIngredient(ingredient, 2);
            Assert.AreEqual(oldStock + 2, stockIngredient.quantité_Stock);
        }

        [TestMethod]
        public void TestRestockIngredient()
        {
            var DB = BDDController.Instance.DB;
            var ingredient = DB.Ingredient.Single(ing => ing.id_Ingredient == 5);
            var stockIngredient = DB.Stock.Single(ing => ing.id_Ingredient == 5);
            int oldStock = (int)stockIngredient.quantité_Stock;
            Assert.IsNotNull(stockIngredient);
            BDDController.Instance.RestockIngredient(ingredient);
            Assert.AreEqual(50, stockIngredient.quantité_Stock);
        }
    }
}
