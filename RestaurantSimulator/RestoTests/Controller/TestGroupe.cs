using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RestoTests.Controller
{
    /// <summary>
    /// Description résumée pour TestGroupe
    /// </summary>
    [TestClass]
    public class TestGroupe
    {
        Groupe Tgroupe = new Groupe();
        

        public TestGroupe()
        {

        }



        

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestConstruct()
        {

            Assert.AreEqual(Tgroupe.Position, new Vector2(192, 640));
        }

     

        [TestMethod]
        public void TestmoveToTable()
        {
            Tgroupe.isMooving = true;
            while (Tgroupe.isMooving)
            {
                Tgroupe.moveToTable(new Vector2(0, 0));
            }

            Assert.AreEqual(Tgroupe.Position, new Vector2(0, 0));
        }


        [TestMethod]
        public void TestStart()
        {
            Tgroupe.start = true;
            GameTime _gametime = new GameTime();
            while (Tgroupe.start)
            {
                Tgroupe.Start(_gametime);
            }

            Assert.AreEqual(Tgroupe.Position.Y, 512);
        }
    }
}
