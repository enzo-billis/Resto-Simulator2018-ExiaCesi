using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSimulator.Controller.Kitchen;
using RestaurantSimulator.Model.Salle.Components;

namespace RestaurantSimulator.Controller.Salle
{
    public static class EquipmentController
    {
        public static bool defineAsDirty(string elem)
        {
            bool existDirty = StockEquipment.Instance.Dirty.TryGetValue(elem, out int eNumberDirty);
            bool existInUse = StockEquipment.Instance.InUse.TryGetValue(elem, out int eNumberInUse);
            if ((existDirty) && (existInUse) && (eNumberInUse > 0))
            {
                StockEquipment.Instance.InUse[elem] = eNumberInUse - 1;
                StockEquipment.Instance.Dirty[elem] = eNumberDirty + 1;
                KitchenCleanerController.checkCleaning();
                return true;
            }
            return false;
        }

        public static bool defineAsInUse(string elem)
        {
            bool existClean = StockEquipment.Instance.Clean.TryGetValue(elem, out int eNumberClean);
            bool existInUse = StockEquipment.Instance.InUse.TryGetValue(elem, out int eNumberInUse);
            if ((existClean) && (existInUse) && (eNumberClean > 0))
            {
                StockEquipment.Instance.InUse[elem] = eNumberInUse + 1;
                StockEquipment.Instance.Clean[elem] = eNumberClean - 1;
                return true;
            }
            return false;
        }

        public static bool defineAsClean(string elem)
        {
            bool existWashing = StockEquipment.Instance.Washing.TryGetValue(elem, out int eNumberWashing);
            bool existClean = StockEquipment.Instance.Clean.TryGetValue(elem, out int eNumberClean);
            if ((existClean) && (existWashing) && (eNumberWashing > 0))
            {
                StockEquipment.Instance.Clean[elem] = eNumberClean + 1;
                StockEquipment.Instance.Washing[elem] = eNumberWashing - 1;
                return true;
            }
            return false;
        }

        public static bool defineAsWashing(string elem)
        {
            bool existWashing = StockEquipment.Instance.Washing.TryGetValue(elem, out int eNumberWashing);
            bool existDirty = StockEquipment.Instance.Dirty.TryGetValue(elem, out int eNumberDirty);
            if ((existDirty) && (existWashing) && (eNumberDirty > 0))
            {
                StockEquipment.Instance.Washing[elem] = eNumberWashing + 1;
                StockEquipment.Instance.Dirty[elem] = eNumberDirty - 1;
                return true;
            }
            return false;
        }
    }
}
