using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixeldude;
        Rectangle pixelRect;
        int jumpHeight;
        bool canJump;
        Texture2D platform;
        Rectangle platformRect;
        KeyboardState oldKeyboardState;
        KeyboardState newKeyboardState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1042;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();

            pixelRect.X = 0;
            pixelRect.Y = 700 - 35;
            pixelRect.Width = 30;
            pixelRect.Height = 35;
            //first platform
            platformRect.X = 500;
            platformRect.Y = 700-60;
            platformRect.Width = 150;
            platformRect.Height = 20;

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
            //change later, he is very ugly
            pixeldude = Content.Load<Texture2D>("pixeldude");
            platform = Content.Load<Texture2D>("pixel");

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
            newKeyboardState = Keyboard.GetState();
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //  Exit();

            if (newKeyboardState.IsKeyDown(Keys.Escape))
                Exit();

            

            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                pixelRect.X -= 2;
            }

            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                pixelRect.X += 2;
            }
            
            if (newKeyboardState.IsKeyDown(Keys.Up) && jumpHeight < 70 && canJump)
            {
                    pixelRect.Y -= 2;
                    jumpHeight += 2;
            }
            else if (jumpHeight > 0)
            {
                pixelRect.Y += 3;
                jumpHeight -= 3;
            }
            if (jumpHeight >= 70)
            {
                canJump = false;
            }
               
           // if (newKeyboardState.IsKeyUp(Keys.Up) && jumpHeight > 0)
            //{
              //  pixelRect.Y += 3;
                //jumpHeight -= 3;
            //}
            if(jumpHeight <= 0)
            {
                canJump = true;
            }

            if (pixelRect.X < 0)
            {
                pixelRect.X = 0;
            }
            if (pixelRect.X > GraphicsDevice.Viewport.Width - pixelRect.Width)
            {
                pixelRect.X = GraphicsDevice.Viewport.Width - pixelRect.Width;
            }
            if(pixelRect.Y < 0)
            {
                pixelRect.Y = 0;
            }
            if(pixelRect.Y > GraphicsDevice.Viewport.Height - pixelRect.Height)
            {
                pixelRect.Y = GraphicsDevice.Viewport.Height - pixelRect.Height;
            }
            // TODO: Add your update logic here
            oldKeyboardState = newKeyboardState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(pixeldude, pixelRect ,Color.White);
            spriteBatch.Draw(platform, platformRect, Color.Green);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
