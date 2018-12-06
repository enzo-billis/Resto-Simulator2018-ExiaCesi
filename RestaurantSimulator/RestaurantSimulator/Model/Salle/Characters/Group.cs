using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Salle.Characters
{

    enum GroupState {
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

    class Group
    {
        public int ID;
        //private List<Client> clients;
    }
}
