using Restaurant.Model.Salle.Components;
using Restaurant.Model.Shared;
using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller
{
    public class TableController
    {
        public Table OptimizedFindTable(List<Table> tables, int groupSize)
        {
            if (groupSize <= 10)
            {
                int i = groupSize;
                while (i <= 10)
                {
                    if (tables.Exists(table => table.NbPlaces == i && table.State == EquipmentState.Available))
                        return tables.Find(table => table.NbPlaces == i && table.State == EquipmentState.Available);
                    i++;
                } 



            }
            return null;
        }

        public bool AttributionTableGroup(Group group, Table table)
        {
            if((table.State == EquipmentState.Available) 
                && (table.NbPlaces >= group.Clients.Count))
            {
                table.Group = group;
                table.State = EquipmentState.InUse;
                group.State = GroupState.Ordering;
                return true;
            }
            return false;
        }

        public static void CleanTable(Table table)
        {
            if (table.State == EquipmentState.Dirty)
                table.State = EquipmentState.Available;
        }

        public void DriveGroupTable(Table table, RankChief rankChief)
        {
            if (table.Group != null)
            {
                table.Group.Move(table.PosX, table.PosY);
                rankChief.Move(table.PosX - 32, table.PosY);
            }
        }

        public static bool Restock(Table table)
        {
            if((table.State == EquipmentState.InUse) && (table.Group != null))
            {
                SalleModel.Commis.Move(table.PosX, table.PosY);
                return StockEquipment.Instance.SubstractEquipement("BreadBasket");
            }
            return false;
        }
    }
}
