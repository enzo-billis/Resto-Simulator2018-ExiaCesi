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

namespace RestaurantSimulator.Controller.Kitchen
{
    public static class KitchenReceipeController
    {

        public static Semaphore _cooker = new Semaphore(0, 2);

        private static void CookCallback(Object receipe)
        {
            //Recette ma(Recette)receipe;
            _cooker.WaitOne();

        }

        public static void GetReceipe(Recette receipe)
        {
            if (VerifyDispoTool(receipe))
            {
                string[] steps = Regex.Split(receipe.liste_etapes_recette, ";");
                for(int i = 1; i<steps.Length; i++)
                {
                    Thread t = new Thread(CookCallback);
                    t.Start(receipe);
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
