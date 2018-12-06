using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Shared
{

    public enum GroupState {
        WaitTableAttribution,
        WaitRankChief,
        Ordering,
        TableDispose,
        Ordered,
        WaitEntree,
        WaitPlate,
        WaitDessert,
        WaitBill,
        Dead
    };

    public class Group
    {
        public int ID;
        //private List<Client> clients;
    }
}
