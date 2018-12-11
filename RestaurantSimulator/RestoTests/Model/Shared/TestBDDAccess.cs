using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Model.Shared;
using System.Linq;

namespace RestoTests.Model.Shared
{
    [TestClass]
    public class TestBDDAccess
    {
        [TestMethod]
        public void TestConnectToBDD()
        {
            using(var db = new BDDRestaurant())
            {
                Assert.IsTrue(db.Database.Exists());
            }
        }

        [TestMethod]
        public void TestShowAndAddAndDeleteFromBDD()
        {
            using (var db = new BDDRestaurant())
            {
                Assert.IsTrue(db.Database.Exists());
                var ustenstiles = from ustensile in db.Ustensile
                                  select ustensile;
                foreach(var ustenstile in ustenstiles)
                {
                    Console.WriteLine(ustenstile.nom_ust_Ustensile);
                }

                Ustensile newUstensile = new Ustensile();
                newUstensile.nom_ust_Ustensile = "test";

                db.Ustensile.Add(newUstensile);
                db.SaveChanges();

                var query = from ustensile in db.Ustensile
                                        where ustensile.nom_ust_Ustensile == "test"
                                        select ustensile;

                foreach(Ustensile ust in query)
                    db.Ustensile.Remove(ust);
                db.SaveChanges();
            }
        }
    }
}
