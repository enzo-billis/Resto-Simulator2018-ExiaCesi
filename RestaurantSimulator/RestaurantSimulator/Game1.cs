using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Restaurant.Controller;
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

        int i = 0;
        Groupe groupe;
       

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
            groupe = new Groupe();
            

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
            



            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("restoV2");
            bg2Texture = Content.Load<Texture2D>("blanc");
            groupe.Texture = Content.Load<Texture2D>("groupe9");

            
        }

        
        protected override void UnloadContent()
        {
           
        }

        
        protected override void Update(GameTime gameTime)
        {
            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            RestaurantSimulator.Controller.TimeController.SetTime(gameTime);


            groupe.Update(gameTime, new Vector2(RecSupervision[i].X, RecSupervision[i].Y));
            if (groupe.start)
            {
                groupe.Start(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

                groupe.isMooving = true;

            }


            
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {

                    i = 0;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Z))
                {

                    i = 1;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {

                    i = 2;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {

                    i = 3;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.T))
                {

                    i = 4;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Y))
                {

                    i = 5;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Q))
                {

                    i = 6;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {

                    i = 7;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {

                    i = 8;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.F))
                {

                    i = 9;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.G))
                {

                    i = 10;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.H))
                {

                    i = 11;

                }
           


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 960), Color.White);
            spriteBatch.Draw(bg2Texture, new Rectangle(1280, 0, 320, 960), Color.White);
            groupe.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here


            base.Draw(gameTime);
        }
    }
}
