using Restaurant.Model.Salle.Movement;
using RestaurantSimulator.Model.Salle.Components;
using RestaurantSimulator.Model.Salle.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Salle.Characters
{
    public class RankChief : Position, IMove
    {
        private List<Square> squares;

        public List<Square> Squares { get => squares; set => squares = value; }

        public RankChief()
        {
            this.squares = new List<Square>();
            this.squares.Add(new Square());
        }

        public RankChief(int posX, int posY) : base (posX, posY)
        {
            this.squares = new List<Square>();
            this.squares.Add(new Square());
        }

        public void Move(int posX, int posY)
        {
            this.PosX = posX;
        }
    }
}
