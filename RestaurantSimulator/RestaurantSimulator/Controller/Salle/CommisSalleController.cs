using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Restaurant.Model.Shared;
using RestaurantSimulator.Model.Salle.Components;
using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller.Salle
{
    class CommisSalleController
    {

        public int tile = 32;
        public Vector2 Position;
        public Texture2D Texture;
        public bool isMooving = false;
        private List<Vector2> diffpos;
        int randomNumber = 0;

        public CommisSalleController()
        {
            this.Position = new Vector2(26 * tile, 16 * tile);
            
            



        }

        public void moveTo(Vector2 finalpos)
        {



            if (Position.X > finalpos.X)
            {
                Position.X -= 1 * Parameters.SPEED;
            }
            if (Position.X < finalpos.X)
            {
                Position.X += 1 * Parameters.SPEED;
            }
            if (Position.Y > finalpos.Y)
            {
                Position.Y -= 1 * Parameters.SPEED;
            }
            if (Position.Y < finalpos.Y)
            {
                Position.Y += 1 * Parameters.SPEED;
            }

            if (Position.Y == finalpos.Y && Position.X == finalpos.X)
            {
                isMooving = false;
            }

        }


        private Vector2 rectToVect(Rectangle rect)
        {
            return new Vector2(rect.X, rect.Y);
        }


        public void Update(GameTime _gametime, bool inTable, List<Table> tables)
        {

            



            if (isMooving)
            {
                moveTo(diffpos[randomNumber]);
            }
            else
            {
                diffpos = new List<Vector2>(); ;
                
                foreach (Table t in tables)
                {
                    if(t.Group != null)
                    {
                        diffpos.Add(rectToVect(t.Rect));
                    }
                
                }
                if (diffpos.Count > 0)
                {
                Random random = new Random();
                randomNumber = random.Next(0, (diffpos.Count));
                isMooving = true;
                }
                

            }
        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }


    }
}
