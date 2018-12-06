using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.Controller
{
    class Groupe
    {
        public int rate =32;
        public Texture2D Texture;
        public Vector2 Position;
        public bool isMooving = false;
        public bool start = true;

        public Groupe()
        {
            Position = new Vector2(6*rate,20*rate);
            

        }
        
        public void moveToTable(Vector2 finalpos)
        {
            //Vector2 finalpos = new Vector2(16*rate,14*rate);
            //Vector2 finalpos = new Vector2(4*rate,6*rate);
            //Vector2 finalpos = new Vector2(1 * rate, 14 * rate);
            //Vector2 finalpos = new Vector2(33*rate,20*rate);




            if (Position.X > finalpos.X)
            {
                Position.X --;
            }
            if (Position.X < finalpos.X)
            {
                Position.X++;
            }
            if (Position.Y > finalpos.Y)
            {
                Position.Y--;
            }
            if (Position.Y < finalpos.Y)
            {
                Position.Y +=1;
            }
            
            
            if (Position.Y == finalpos.Y && Position.X == finalpos.X)
            {
                isMooving = false;
            }
            
            




        }
        public void Start(GameTime _gametime)
        {
            if (Position.Y > 16 * rate)
            {
                Position.Y--;
            }
            if(Position.Y == 16 * rate)
            {
                start = false;
            }
            
        }

        public void Update(GameTime _gametime, Vector2 finalpos)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Position.Y == 16 * rate)
            {
                isMooving = true;
                    
            }
            if (isMooving)
            {
                moveToTable(finalpos);
            }




        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }





    }
}
