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
using Restaurant.Model.Salle.Components;

namespace RestaurantSimulator.Controller.Salle
{
    class ServeurController
    {



        public int tile = 32;
        public Vector2 Position;
        private Vector2 Spawn;
        private Vector2 Clients;
        private Group lastGroup= null;
        public Texture2D Texture;
        public bool isMooving = false;
        public bool isCleaning = false;
        public bool toSpawn = false;



        public ServeurController(Vector2 fpos)
        {
            this.Position = fpos;
            Spawn = fpos;




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

        private void cleanTable(List<Table> tables)
        {
            foreach(Table t in tables)
            {
                if(t.State == EquipmentState.Dirty)
                {
                    isCleaning = true;
                    moveTo(rectToVect(t.Rect));
                    if(Position == rectToVect(t.Rect))
                    {
                        t.State = EquipmentState.Available;
                        toSpawn = true;
                        isCleaning = false;
                    }
                    break;
                }
            }
        }
        
        


        private Vector2 rectToVect(Rectangle rect)
        {
            return new Vector2(rect.X, rect.Y);
        }

        public void Update(GameTime _gametime,List<Table> tables)
        {


            if (toSpawn)
            {
                moveTo(Spawn);
            }
            else
            {
                cleanTable(tables);

                if (!isCleaning)
                {
                    foreach(Table t in tables)
                    {
                        if(t.Group != null){
                            if(t.Group != lastGroup)
                            {
                            Clients = rectToVect(t.Rect);
                            lastGroup = t.Group;
                            isMooving = true;
                            break;
                            }
                            
                        }
                    }
                         
                }
                if (isMooving)
                {
                    moveTo(Clients);
                    if(Position == Clients)
                    {
                        toSpawn = true;
                    }
                }
            }


            
            
        }

        public void Draw(SpriteBatch _spritBash)
        {
            _spritBash.Draw(Texture, Position, Color.White);
        }





    }
}
