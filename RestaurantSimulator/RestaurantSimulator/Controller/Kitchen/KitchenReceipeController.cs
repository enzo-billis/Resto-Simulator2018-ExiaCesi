using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSimulator.Model.Shared;
using System.Text.RegularExpressions;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Controller.Kitchen;
using System.Threading;
using RestaurantSimulator.Model.Cuisine.Components;
using System.Diagnostics;

namespace RestaurantSimulator.Controller.Kitchen
{
    public static class KitchenReceipeController
    {
        public static Semaphore _cooker = new Semaphore(0, 2);

        private static void CookCallback(Object obj)
        {
            //Semaphore can be taken
            _cooker.WaitOne();
          
            //Cast the good type -> receipe
            composé receipeCompose = (composé)obj;

            Etape actualStep = BDDController.Instance.DB.Etape.SingleOrDefault(e => e.id_etape == receipeCompose.id_etape);
            Ingredient actualIngr = BDDController.Instance.DB.Ingredient.SingleOrDefault(e => e.id_Ingredient == receipeCompose.id_Ingredient);
            Ustensile ustensile = BDDController.Instance.DB.Ustensile.SingleOrDefault(e => e.id_Ustensile == actualStep.id_Ustensile);
           
            KitchenToolsController kitchenToolsController = new KitchenToolsController();
            
            Console.WriteLine("Quantité de {0} : {1} avant", ustensile.nom_ust_Ustensile, StockKitchenware.Instance.Clean[ustensile.nom_ust_Ustensile]);
            
            kitchenToolsController.SendDirtyTools(ustensile.nom_ust_Ustensile,1);
            Console.WriteLine("Quantité de {0} : {1} après", ustensile.nom_ust_Ustensile, StockKitchenware.Instance.Clean[ustensile.nom_ust_Ustensile]);
            
            
            //Clear stock
            //BDDController.Instance.DB.Stock.Remove...


            Thread.Sleep(Convert.ToInt32(actualStep.temps_etape) * 1000);

            
        }

        public static void GetReceipe(Recette receipe)
        {
            
            if (VerifyDispoTool(receipe))
            {
               
                string[] steps = Regex.Split(receipe.liste_etapes_recette, ";");

                foreach (var step in steps)
                {
                    

                    int stepId = Convert.ToInt32(step);

                    //From BDD we get all objects needed
                    composé actualCompose = BDDController.Instance.DB.composé.SingleOrDefault(c => c.id_compose == stepId);
                  
                    //Foreach steps in the receipe we create a new thread.

                    Thread t = new Thread(CookCallback);
                   
                    t.Start(actualCompose);
                  
                }

                Thread.Sleep(500);
                _cooker.Release();
            }
            
        }

        public static bool VerifyDispoTool(Recette receipe)
        {
            KitchenToolsController kitchenToolsController = new KitchenToolsController();

            string[] steps = Regex.Split(receipe.liste_etapes_recette, ";");
            foreach (var step in steps)
            {
                int actualStepID = Convert.ToInt32(step);

                try
                {
                    composé actualCompose = BDDController.Instance.DB.composé.SingleOrDefault(r => r.id_compose == actualStepID);
                    Etape actualStep = BDDController.Instance.DB.Etape.SingleOrDefault(r => r.id_etape == actualCompose.id_etape);
                    Ustensile actualStepTool = BDDController.Instance.DB.Ustensile.SingleOrDefault(r => r.id_Ustensile == actualStep.id_Ustensile);
                    string toolName = actualStepTool.nom_ust_Ustensile;
                    
                    if (kitchenToolsController.VerifyStock(toolName, 1))
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
