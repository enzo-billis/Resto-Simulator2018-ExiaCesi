using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSimulator.Model.Shared;
using System.Text.RegularExpressions;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Controller.Kitchen;

namespace RestaurantSimulator.Controller.Kitchen
{
    public class KitchenReceipeController
    {
        public void CookCallback(Recette receipe)
        {

        }

        public void GetReceipe(Recette receipe)
        {
            
        }

        public bool VerifyDispoTool(Recette receipe)
        {
            KitchenToolsController kitchenToolsController = new KitchenToolsController();

            string[] steps = Regex.Split(receipe.liste_etapes_recette, ";");
            foreach (var step in steps)
            {
                int actualStepID = Convert.ToInt32(step);

                try
                {
                    Etape actualStep = BDDController.Instance.DB.Etape.SingleOrDefault(r => r.id_etape == actualStepID);
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

        public void FreeSemaphReceipe()
        {
            
        }
    }
}
