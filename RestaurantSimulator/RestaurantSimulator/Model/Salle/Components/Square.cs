using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    class Square
    {
        private List<Table> Tables;
        private List<Waiter> Waiters;
        private List<RankChief> RankChiefs;

        public List<Waiter> Waiters1 { get => Waiters; set => Waiters = value; }
        public List<RankChief> RankChiefs1 { get => RankChiefs; set => RankChiefs = value; }
        internal List<Table> Tables1 { get => Tables; set => Tables = value; }
    }
}
