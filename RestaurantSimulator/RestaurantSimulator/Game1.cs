using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Restaurant.Controller;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Model.Salle.Components;
using System.Collections.Generic;
using RestaurantSimulator.Model;
using RestaurantSimulator.Model.Shared;
using RestaurantSimulator.Controller.Salle;
//using RestaurantSimulator.Controller;


namespace RestaurantSimulator
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        
        int tile = 32;
        private SpriteFont timer, fontInfo;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D bgTexture;
        Texture2D bg2Texture;
        List<Rectangle> RecSupervision = new List<Rectangle>();
        List<Texture2D> TextPerso = new List<Texture2D>();
        private SalleModel salleModel;
        private TableController tableController;
        private WelcomeController welcomeC;
        private List<string> data = new List<string>();
        private List<Table> tables;
        int timeSec;



        public Vector2 posch1;
        public Vector2 posch2;

        int i = 0;


        PlayPauseController playPauseButtons;
        GroupeController groupe;
        GroupeController groupe2;
        CuistoController cuisto;
        ServeurController serveur1;
        PlongeurController plongeur;
        CommisCuisineController commisCuisine;
        CommisSalleController commisSalle;





        public SalleModel SalleModel { get => salleModel; set => salleModel = value; }
        public TableController TableController { get => tableController; set => tableController = value; }








        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            welcomeC = new WelcomeController(salleModel.HotelMaster);
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 960;
            graphics.PreferredBackBufferWidth = 1600;
            graphics.ApplyChanges();
            groupe = new GroupeController(welcomeC.CreateGroup(4));
            groupe2 = new GroupeController(welcomeC.CreateGroup(9));
            cuisto = new CuistoController();
            serveur1 = new ServeurController(new Vector2(25*tile,17*tile));
            posch1 = salleModel.HotelMaster.RankChiefs[0].FPosition;
            posch2 = salleModel.HotelMaster.RankChiefs[1].FPosition;
            tableController = new TableController();
            playPauseButtons = new PlayPauseController();
            tables = new List<Table>();
            plongeur = new PlongeurController() ;
            commisCuisine = new CommisCuisineController();
            commisSalle = new CommisSalleController();

            data.Add(" ");
            data.Add(" ");
            data.Add(" ");
            data.Add(" ");
            data.Add(" ");
            data.Add(" ");


        

            TextPerso.Add(Content.Load<Texture2D>("cuisto"));
            TextPerso.Add(Content.Load<Texture2D>("commis"));
            TextPerso.Add(Content.Load<Texture2D>("serveur"));
            TextPerso.Add(Content.Load<Texture2D>("client1"));
            TextPerso.Add(Content.Load<Texture2D>("groupe3"));
            TextPerso.Add(Content.Load<Texture2D>("groupe4"));
            TextPerso.Add(Content.Load<Texture2D>("groupe7"));
            TextPerso.Add(Content.Load<Texture2D>("groupe9"));
            TextPerso.Add(Content.Load<Texture2D>("client2"));


            base.Initialize();
        }

        
        protected override void LoadContent()
        {
          

            spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("restoV2");
            bg2Texture = Content.Load<Texture2D>("blanc");
            groupe.Texture = Content.Load<Texture2D>("groupe" + groupe.group.Clients.Count);
            groupe2.Texture = Content.Load<Texture2D>("groupe"+groupe2.group.Clients.Count);
            salleModel.HotelMaster.RankChiefs[0].Texture = TextPerso[3];
            salleModel.HotelMaster.RankChiefs[1].Texture = TextPerso[3];
            timer = Content.Load<SpriteFont>("Timer");
            fontInfo = Content.Load<SpriteFont>("infos");
            cuisto.Texture = TextPerso[0];
            serveur1.Texture = TextPerso[2];
            playPauseButtons.TexturePause = Content.Load<Texture2D>("pause");
            playPauseButtons.TextureX1 = Content.Load<Texture2D>("playX1");
            playPauseButtons.TextureX16 = Content.Load<Texture2D>("playX16");


            plongeur.Texture = TextPerso[8];
            commisCuisine.Texture = TextPerso[8];
            commisSalle.Texture = TextPerso[1];


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


            MouseState Mstate = Mouse.GetState();
            playPauseButtons.Update(gameTime,Mstate);


            tables = new List<Table>();


            foreach (Table t in SalleModel.HotelMaster.RankChiefs[0].Squares[0].Tables)
            {
                tables.Add(t);
            }
            foreach (Table t in SalleModel.HotelMaster.RankChiefs[1].Squares[0].Tables)
            {
                tables.Add(t);
            }






            // TODO: Add your update logic here
            RestaurantSimulator.Controller.TimeController.SetTime(gameTime);
            timeSec = TimeController.GetTimer();
            cuisto.Update(gameTime,groupe.inTable);
            groupe.Update(gameTime, groupe.PosTable);
            groupe2.Update(gameTime, groupe2.PosTable);
            plongeur.Update(gameTime);
            commisCuisine.Update(gameTime, groupe.inTable);
            commisSalle.Update(gameTime, groupe.inTable, tables);


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

                if (!groupe.inTable)
                {
                    putGroupToTable(groupe);
                }

                if (!groupe2.inTable)
                {
                    putGroupToTable(groupe2);
                }
                


            }
            serveur1.Update(gameTime, salleModel.HotelMaster.RankChiefs[0].Squares[0].Tables);
            
            salleModel.HotelMaster.RankChiefs[0].Update(gameTime,posch1);
            salleModel.HotelMaster.RankChiefs[1].Update(gameTime,posch2);





            if(Mstate.LeftButton == ButtonState.Pressed)
            {
                foreach (Table t in salleModel.HotelMaster.RankChiefs[0].Squares[0].Tables)
                {
                    Rectangle rect = t.Rect;
                        if(Mstate.X >= rect.Left && Mstate.X <= rect.Right && Mstate.Y >= rect.Top && Mstate.Y <= rect.Bottom)
                        {
                            data[0] = "Etat de la table : " + t.State;
                            data[1] = "Nombre de places : " + t.NbPlaces;
                            if(t.Group != null)
                            {
                                data[2] = "Groupe de "+t.Group.Clients.Count+" personnes";
                                data[3] = "Etat de l'entree : " + (t.Entree?"Fini":"En cours");
                                data[4] = "Etat du plat : " + (t.Plate?"Fini":(t.Entree?"En cours":"En attente"));
                                data[5] = "Etat du dessert : "+ (t.Dessert ? "Fini" : (t.Plate ? "En cours" : "En attente"));

                            }
                            else
                            {
                                data[2] = "Pas de groupe";
                                data[3] = "Etat de l'entree : Pas de groupe";
                                data[4] = "Etat du plat : Pas de groupe";
                                data[5] = "Etat du dessert : Pas de groupe";
                            }
                            break;
                        }
                        
                }
                foreach (Table t in salleModel.HotelMaster.RankChiefs[1].Squares[0].Tables)
                {
                    Rectangle rect = t.Rect;
                    if (Mstate.X >= rect.Left && Mstate.X <= rect.Right && Mstate.Y >= rect.Top && Mstate.Y <= rect.Bottom)
                    {
                        data[0] = "Etat de la table : " + t.State;
                        data[1] = "Nombre de places : " + t.NbPlaces;
                        if (t.Group != null)
                        {
                            data[2] = "Groupe de " + t.Group.Clients.Count + " personnes";
                            data[3] = "Etat de l'entree : " + (t.Entree ? "Fini" : "En cours");
                            data[4] = "Etat du plat : " + (t.Plate ? "Fini" : (t.Entree ? "En cours" : "En attente"));
                            data[5] = "Etat du dessert : " + (t.Dessert ? "Fini" : (t.Plate ? "En cours" : "En attente"));

                        }
                        else
                        {
                            data[2] = "Pas de groupe";
                            data[3] = "Etat de l'entree : Pas de groupe";
                            data[4] = "Etat du plat : Pas de groupe";
                            data[5] = "Etat du dessert : Pas de groupe";
                        }
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


                Table table = tableController.OptimizedFindTable(salleModel.HotelMaster.RankChiefs[0].Squares[0].Tables, groupe.group.Clients.Count);
                if (table != null)
                {
                    tableController.AttributionTableGroup(groupe.group, table);
                    salleModel.HotelMaster.RankChiefs[0].isMooving = true;
                    salleModel.HotelMaster.RankChiefs[0].Available = false;
                    posch1 = rectToVect(table.Rect);
                    groupe.PosTable = posch1;
                    groupe.isMooving = true;
                    groupe.inTable = true;
                    
                }

            }
            else if (salleModel.HotelMaster.RankChiefs[1].Available)
            {


                Table table = tableController.OptimizedFindTable(salleModel.HotelMaster.RankChiefs[1].Squares[0].Tables, groupe.group.Clients.Count);
                if (table != null)
                {
                    
                    tableController.AttributionTableGroup(groupe.group, table);
                    salleModel.HotelMaster.RankChiefs[1].isMooving = true;
                    salleModel.HotelMaster.RankChiefs[1].Available = false;
                    posch2 = rectToVect(table.Rect);
                    groupe.PosTable = posch2;
                    groupe.isMooving = true;
                    groupe.inTable = true;

                }

            }

        }






        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 960), Color.White);
            spriteBatch.Draw(bg2Texture, new Rectangle(1280, 0, 320, 960), Color.White);
            spriteBatch.DrawString(timer, "Temps : "+ timeSec, new Vector2(1280, 0), Color.Black);
            int posInfo = 100;
            foreach(string info in data)
            {
                //System.Console.WriteLine(info);
                spriteBatch.DrawString(fontInfo, info, new Vector2(1280, posInfo), Color.Black);
                posInfo += 30;
            }
            cuisto.Draw(spriteBatch);
            groupe.Draw(spriteBatch);
            groupe2.Draw(spriteBatch);
            salleModel.HotelMaster.RankChiefs[0].Draw(spriteBatch);
            salleModel.HotelMaster.RankChiefs[1].Draw(spriteBatch);
            serveur1.Draw(spriteBatch);
            playPauseButtons.Draw(spriteBatch);

            plongeur.Draw(spriteBatch);
            commisCuisine.Draw(spriteBatch);
            commisSalle.Draw(spriteBatch);


            spriteBatch.End();
           
            

            base.Draw(gameTime);
        }
    }
}
