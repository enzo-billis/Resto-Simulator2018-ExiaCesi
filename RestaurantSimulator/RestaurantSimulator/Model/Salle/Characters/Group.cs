using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Salle.Characters
{

    enum GroupState {
        waitTableAttribution,
        waitRankChief,
        ordering,
        tableDispose,
        ordered,
        waitEntree,
        waitPlate,
        waitDessert,
        waitBill,
        dead
    };

    class Group
    {
        public int ID;
        //private List<Client> clients;
    }
}
