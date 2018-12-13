﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Restaurant.Controller;
using RestaurantSimulator.Controller;
using RestaurantSimulator.Model.Salle.Components;
using System.Collections.Generic;
using RestaurantSimulator.Model;
using RestaurantSimulator.Model.Shared;
using RestaurantSimulator.Controller.Salle;
using System;
using RestaurantSimulator.Model.Salle.Characters;
using System.Threading;
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
        private List<Table> tables, tablesInUse;
        private List<GroupeController> LGroupes;
        int timeSec;
        bool bill = true;



        public Vector2 posch1;
        public Vector2 posch2;

        int i = 0;


        PlayPauseController playPauseButtons;
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


            LGroupes = new List<GroupeController>();
            LGroupes.Add(new GroupeController(welcomeC.CreateGroup(5)));
            






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


            /*
            MapController.UpdateMap();
            Client client = new Client();
            Recette recette = MapController.GetMap().Recettes[0];
            groupe.group.Clients.ForEach(c => c.Entree = recette);
            groupe.group.State = Restaurant.Model.Shared.GroupState.WaitDessert;
            ThreadPool.QueueUserWorkItem(SalleCommandsController.Instance.SendCommand, groupe.group);
            //SalleCommandsController.Instance.SendCommand(groupe.group);

    */
        

            TextPerso.Add(Content.Load<Texture2D>("cuisto"));
            TextPerso.Add(Content.Load<Texture2D>("commis"));
            TextPerso.Add(Content.Load<Texture2D>("serveur"));
            TextPerso.Add(Content.Load<Texture2D>("client1"));
            TextPerso.Add(Content.Load<Texture2D>("groupe3"));
            TextPerso.Add(Content.Load<Texture2D>("groupe4"));
            TextPerso.Add(Content.Load<Texture2D>("groupe7"));
            TextPerso.Add(Content.Load<Texture2D>("groupe9"));
            TextPerso.Add(Content.Load<Texture2D>("client2"));
            TextPerso.Add(Content.Load<Texture2D>("perso5"));
            TextPerso.Add(Content.Load<Texture2D>("perso6"));
            TextPerso.Add(Content.Load<Texture2D>("perso8"));



            base.Initialize();
        }

        
        protected override void LoadContent()
        {
          

            spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("restoV2");
            bg2Texture = Content.Load<Texture2D>("blanc");



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
            tablesInUse = new List<Table>();


            foreach (Table t in SalleModel.HotelMaster.RankChiefs[0].Squares[0].Tables)
            {
                tables.Add(t);
                if(t.Group != null)
                {
                    tablesInUse.Add(t);
                }
            }
            foreach (Table t in SalleModel.HotelMaster.RankChiefs[1].Squares[0].Tables)
            {
                tables.Add(t);
                if (t.Group != null)
                {
                    tablesInUse.Add(t);
                }
            }







            // TODO: Add your update logic here
            RestaurantSimulator.Controller.TimeController.SetTime(gameTime);
            timeSec = TimeController.GetTimer();


            if ((gameTime.TotalGameTime.Seconds % 30 == 0))
            {
                if (bill)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(3, 9);

                    LGroupes.Add(new GroupeController(welcomeC.CreateGroup(randomNumber)));
                    bill = false;
                }
            }
            else
            {
                bill = true;
            }


            
            
            plongeur.Update(gameTime);
            commisCuisine.Update(gameTime, LGroupes[0].inTable);
            commisSalle.Update(gameTime, LGroupes[0].inTable, tables);
            cuisto.Update(gameTime, LGroupes[0].inTable);

            foreach(GroupeController groupe in LGroupes)
            {
                groupe.Texture = updateTexure(groupe.group.Clients.Count);



                if (groupe.start)
                {
                    groupe.Start(gameTime);
                }
                else
                {
                    if (!groupe.inTable)
                    {
                        putGroupToTable(groupe);
                    }
                    groupe.Update(gameTime, groupe.PosTable);
                }


            }


            serveur1.Update(gameTime, tables);
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

        private Texture2D updateTexure(int nbpersonnes)
        {
            

            switch (nbpersonnes)
            {
                case 3:
                    return TextPerso[4];

                    break;
                case 4:
                    return TextPerso[5];

                    break;
                case 5:

                    return TextPerso[9];
                    break;
                case 6:

                    return TextPerso[4];
                    break;
                case 7:

                    return TextPerso[10];
                    break;
                case 8:
                    return TextPerso[11];
                    break;
                case 9:
                    return TextPerso[6];
                    break;
            }
            return TextPerso[6];
        }
 




        public void putGroupToTable(GroupeController groupe)
        {
            if (salleModel.HotelMaster.RankChiefs[0].Available)
            {
                foreach (Table t in salleModel.HotelMaster.RankChiefs[0].Squares[0].Tables)
                {
                    if (t.Group != null || t.NbPlaces < groupe.group.Clients.Count)
                    {
                        salleModel.HotelMaster.RankChiefs[0].Available = false;
                    }
                    else
                    {
                        salleModel.HotelMaster.RankChiefs[0].Available = true;
                        break;
                    }
                }

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
            

            foreach(GroupeController groupe in LGroupes)
            {
                groupe.Draw(spriteBatch);
            }

            cuisto.Draw(spriteBatch);
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
