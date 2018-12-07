using Restaurant.Model.Salle.Movement;
using RestaurantSimulator.Model.Salle.Characters;
using RestaurantSimulator.Model.Salle.Movement;
using System.Collections.Generic;

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

    public class Group : Position, IMove
    {
        private int id;
        private List<Client> clients;
        private static int GroupCounter = 1;

        public int ID { get => id; set => id = value; }
        public List<Client> Clients { get => clients; set => clients = value; }

        public Group() : base()
        {
            this.clients = new List<Client>();
            this.id = GroupCounter;
            GroupCounter++;
        }

        public Group(int posX, int posY) : base (posX, posY)
        {
            this.clients = new List<Client>();
            this.id = GroupCounter;
            GroupCounter++;
        }

        public void Move(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }
}
