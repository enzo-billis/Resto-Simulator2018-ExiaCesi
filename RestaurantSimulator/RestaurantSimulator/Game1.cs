using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Restaurant.Controller;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Model.Salle.Components;
using System.Collections.Generic;
//using RestaurantSimulator.Controller;


namespace RestaurantSimulator
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        int tile = 32;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D bgTexture;
        Texture2D bg2Texture;
        List<Rectangle> RecSupervision = new List<Rectangle>();
        List<Texture2D> TextPerso = new List<Texture2D>();
        private SalleModel salleModel;
        private TableController tableController;

        public Vector2 posch1;
        public Vector2 posch2;

        int i = 0;
        GroupeController groupe;
        GroupeController groupe2;

        public SalleModel SalleModel { get => salleModel; set => salleModel = value; }
        public TableController TableController { get => tableController; set => tableController = value; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 960;
            graphics.PreferredBackBufferWidth = 1600;
            graphics.ApplyChanges();
            groupe = new GroupeController();
            groupe2 = new GroupeController();
            posch1 = salleModel.HotelMaster.RankChiefs[0].FPosition;
            posch2 = salleModel.HotelMaster.RankChiefs[1].FPosition;
            tableController = new TableController();




            RecSupervision.Add(new Rectangle(16 * tile, 14 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(4 * tile, 7 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(1 * tile, 14 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(12 * tile, 7 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(12 * tile, 1 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(18 * tile, 1 * tile, 5 * tile, 5 * tile));

            RecSupervision.Add(new Rectangle(33 * tile, 20 * tile, 5 * tile, 5 * tile));           
            RecSupervision.Add(new Rectangle(24 * tile, 1 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(32 * tile, 1 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(25 * tile, 13 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(22 * tile, 7 * tile, 5 * tile, 5 * tile));
            RecSupervision.Add(new Rectangle(30 * tile, 7 * tile, 5 * tile, 5 * tile));




            TextPerso.Add(Content.Load<Texture2D>("cuisto"));
            TextPerso.Add(Content.Load<Texture2D>("commis"));
            TextPerso.Add(Content.Load<Texture2D>("serveur"));
            TextPerso.Add(Content.Load<Texture2D>("client1"));
            TextPerso.Add(Content.Load<Texture2D>("groupe3"));
            TextPerso.Add(Content.Load<Texture2D>("groupe4"));
            TextPerso.Add(Content.Load<Texture2D>("groupe7"));
            TextPerso.Add(Content.Load<Texture2D>("groupe9"));


            base.Initialize();
        }

        
        protected override void LoadContent()
        {
          

        spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("restoV2");
            bg2Texture = Content.Load<Texture2D>("blanc");
            groupe.Texture = TextPerso[5];
            groupe2.Texture = TextPerso[6];
            salleModel.HotelMaster.RankChiefs[0].Texture = TextPerso[3];
            salleModel.HotelMaster.RankChiefs[1].Texture = TextPerso[3];


        }

        
        protected override void UnloadContent()
        {
           
        }
        private Vector2 rectToVect(Rectangle rect)
        {
            return new Vector2(rect.X, rect.Y);
        }

        protected override void Update(GameTime gameTime)
        {
            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            RestaurantSimulator.Controller.TimeController.SetTime(gameTime);


            groupe.Update(gameTime, groupe.PosTable);
            groupe2.Update(gameTime, groupe2.PosTable);
            if (groupe.start)
            {
                groupe.Start(gameTime);
            }
            if (groupe2.start)
            {
                groupe2.Start(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {


                putGroupToTable(groupe);
                putGroupToTable(groupe2);


            }
            
            salleModel.HotelMaster.RankChiefs[0].Update(gameTime,posch1);
            salleModel.HotelMaster.RankChiefs[1].Update(gameTime,posch2);





            MouseState Mstate = Mouse.GetState();
            if(Mstate.LeftButton == ButtonState.Pressed)
            {
                foreach (Table t in salleModel.HotelMaster.RankChiefs[0].Squares[0].Tables)
                {
                    Rectangle rect = t.Rect;
                        if(Mstate.X >= rect.Left && Mstate.X <= rect.Right && Mstate.Y >= rect.Top && Mstate.Y <= rect.Bottom)
                        {
                            System.Console.WriteLine("oui");
                            System.Console.WriteLine("Etat : "+t.State);
                            System.Console.WriteLine("Nbplace"+t.NbPlaces);
                            System.Console.WriteLine("Groupe"+t.Group);
                            
                        break;
                        }
                        
                }
               

                foreach (Table t in salleModel.HotelMaster.RankChiefs[1].Squares[0].Tables)
                {
                    Rectangle rect = t.Rect;
                    if (Mstate.X >= rect.Left && Mstate.X <= rect.Right && Mstate.Y >= rect.Top && Mstate.Y <= rect.Bottom)
                    {
                        System.Console.WriteLine("oui");
                        System.Console.WriteLine("Etat : " + t.State);
                        System.Console.WriteLine("Nbplace" + t.NbPlaces);
                        System.Console.WriteLine("Groupe" + t.Group);

                        break;
                    }

                }

            }
            




            base.Update(gameTime);
        }
        private void putGroupToTable(GroupeController groupe)
        {
            if (salleModel.HotelMaster.RankChiefs[0].Available)
            {


                Table table = tableController.OptimizedFindTable(salleModel.HotelMaster.RankChiefs[0].Squares[0].Tables, 4);
                if (table != null)
                {
                    salleModel.HotelMaster.RankChiefs[0].isMooving = true;
                    salleModel.HotelMaster.RankChiefs[0].Available = false;
                    posch1 = rectToVect(table.Rect);
                    groupe.PosTable = posch1;
                    groupe.isMooving = true;
                    tableController.AttributionTableGroup(groupe.group, table);
                }

            }
            else if (salleModel.HotelMaster.RankChiefs[1].Available)
            {


                Table table = tableController.OptimizedFindTable(salleModel.HotelMaster.RankChiefs[1].Squares[0].Tables, 7);
                if (table != null)
                {
                    salleModel.HotelMaster.RankChiefs[1].Available = false;

                    salleModel.HotelMaster.RankChiefs[1].isMooving = true;
                    posch2 = rectToVect(table.Rect);
                    groupe.PosTable = posch2;
                    groupe.isMooving = true;
                    tableController.AttributionTableGroup(groupe.group, table);
                }

            }

        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 960), Color.White);
            spriteBatch.Draw(bg2Texture, new Rectangle(1280, 0, 320, 960), Color.White);
            groupe.Draw(spriteBatch);
            groupe2.Draw(spriteBatch);
            salleModel.HotelMaster.RankChiefs[0].Draw(spriteBatch);
            salleModel.HotelMaster.RankChiefs[1].Draw(spriteBatch);





            spriteBatch.End();
           
            

            base.Draw(gameTime);
        }
    }
}
