using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Restaurant.Model.Shared;
using RestaurantSimulator.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller.Salle
{
    public class CuistoController
    {
        public int tile = 32;
        public Vector2 Position;
        public Texture2D Texture;
        public bool isMooving = false;
        private List<Vector2> diffpos;
        int randomNumber = 0;

        public CuistoController()
        {
            this.Position = new Vector2(20*tile,20*tile);
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            diffpos.Add(new Vector2(20 * tile, 20 * tile));
            

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



        public void Update(GameTime _gametime, Vector2 finalpos)
        {

            



            if (isMooving)
            {
                moveTo(diffpos[randomNumber]);
            }
            else
            {
                Random random = new Random();
                randomNumber = random.Next(0, (diffpos.Count-1));
                isMooving = true;

            }
        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }



    }
}
