using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Restaurant.Controller;
using System.Collections.Generic;

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
        Vector2 bgPosition;
        Texture2D bgTexture;
        Texture2D bg2Texture;
        List<Rectangle> rectangles;
        

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


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("restoV2");
            bg2Texture = Content.Load<Texture2D>("blanc");
            groupe.Texture = Content.Load<Texture2D>("groupe9");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            System.Console.WriteLine(gameTime.TotalGameTime);
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            groupe.Update(gameTime, new Vector2(1 * tile, 14 * tile));
            if (groupe.start)
            {
                groupe.Start(gameTime);
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
