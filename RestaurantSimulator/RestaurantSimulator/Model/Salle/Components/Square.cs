using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Components
{
    public class Square
    {
        private List<Table> tables;
        private List<Waiter> waiters;
        private List<RankChief> rankChiefs;

        public List<Waiter> Waiters { get => waiters; set => waiters = value; }
        public List<RankChief> RankChiefs { get => rankChiefs; set => rankChiefs = value; }
        public List<Table> Tables { get => tables; set => tables = value; }

        public Square()
        {
            this.tables = new List<Table>();
            this.waiters = new List<Waiter>();
            this.rankChiefs = new List<RankChief>();
            this.tables.Add(new Table(2));
            this.tables.Add(new Table(4));
            this.tables.Add(new Table(6));
            this.tables.Add(new Table(6));
            this.tables.Add(new Table(8));
            this.tables.Add(new Table(10));

            for (int i = 0; i < Parameters.WAITER_BY_SQUARE; i++)
                this.waiters.Add(new Waiter());
        }
    }
}
