using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        BoundaryRectangle boundDude;
        int jumpHeight;
        bool canJump;
        Texture2D platform;
        Rectangle platformRect;
        Texture2D platformTwo;
        Rectangle platTwoRect;
        Texture2D movingPlatform;
        Rectangle movinPlatRect;
        BoundaryRectangle boundMovinPlat;
        BoundaryRectangle boundPlatTwo;
        BoundaryRectangle boundPlat;
        int platformVelocity;
        KeyboardState oldKeyboardState;
        KeyboardState newKeyboardState;
        int runDirection;
        int jumpDirection;
        int groundLevel;
        bool isOnPlatform;
        bool blackHole;
        Texture2D platformThree;
        Rectangle platThreeRect;
        BoundaryRectangle boundPlatThree;
        Texture2D platformFour;
        Rectangle platFourRect;
        BoundaryRectangle boundPlatFour;
        

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

            //pixel dude
            pixelRect.Width = 65;
            pixelRect.Height = 75;
            pixelRect.X = 0;
            pixelRect.Y = 700 - pixelRect.Height;
            boundDude = new BoundaryRectangle(pixelRect.X, pixelRect.Y, pixelRect.Width, pixelRect.Height);
            groundLevel = 700 - pixelRect.Height;

            //first platform
            platformRect.Width = 190;
            platformRect.Height = 150;
            platformRect.X = 500;
            platformRect.Y = 660-platformRect.Height;
           
            boundPlat = new BoundaryRectangle(platformRect.X+ 50, platformRect.Y+ (platformRect.Height/2), 60, 1);


            //second platform
            platTwoRect.Width = 190;
            platTwoRect.Height = 150;
            platTwoRect.X = 280;
            platTwoRect.Y = 530 - platTwoRect.Height;

            boundPlatTwo = new BoundaryRectangle(platTwoRect.X + 50, platTwoRect.Y + (platTwoRect.Height / 2), 60, 1);

            //moving platform
            movinPlatRect.Width = 150;
            movinPlatRect.Height = 100;
            movinPlatRect.X = 0 + movinPlatRect.Width;
            movinPlatRect.Y = 540 - movinPlatRect.Height;

            boundMovinPlat = new BoundaryRectangle(movinPlatRect.X + 50, movinPlatRect.Y + (movinPlatRect.Height/2), 60 , 1);

            //Third Platform
            platThreeRect.Width = 190;
            platThreeRect.Height = 150;
            platThreeRect.X = 230;
            platThreeRect.Y = 400 - platThreeRect.Height;

            boundPlatThree = new BoundaryRectangle(platThreeRect.X + 50, platThreeRect.Y + (platThreeRect.Height / 2), 60, 1);

            //Fourth Platform
            platFourRect.Width = 190;
            platFourRect.Height = 150;
            platFourRect.X = 570;
            platFourRect.Y = 300 - platFourRect.Height;

            boundPlatFour = new BoundaryRectangle(platFourRect.X + 50, platFourRect.Y + (platFourRect.Height/2),60,1);

            platformVelocity = 5;
            runDirection = 0;
            jumpDirection = 0;
            isOnPlatform = false;
            canJump = true;
            blackHole = false;

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
            pixeldude = Content.Load<Texture2D>("Steve");
            platform = Content.Load<Texture2D>("Grass Platform");
            platformTwo = Content.Load<Texture2D>("Grass Platform");
            movingPlatform = Content.Load<Texture2D>("Black Hole");
            platformThree = Content.Load<Texture2D>("Grass Platform");
            platformFour = Content.Load<Texture2D>("Grass Platform");

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
            jumpDirection = 0;
            runDirection = 0;
            

            if (newKeyboardState.IsKeyDown(Keys.Escape))
                Exit();

            
            //run left
            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                //pixelRect.X -= 2;
                runDirection -= (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.2);
                
            }
            //else if(newKeyboardState.IsKeyDown(Keys.Left) && boundDude.CollidesWith(boundMovinPlat))
            //{
            //    runDirection -= (2 - platformVelocity);
            //}
            //else if (boundDude.CollidesWith(boundMovinPlat))
            //{
            //    runDirection = platformVelocity;
            //}
            //run right
            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                //pixelRect.X += 2;
                runDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.2);
            }
            //else if (newKeyboardState.IsKeyDown(Keys.Right) && boundDude.CollidesWith(boundMovinPlat))
            //{
            //    runDirection += 2 + platformVelocity;
            //}
            //else if (boundDude.CollidesWith(boundMovinPlat))
            //{
            //    runDirection = platformVelocity;
            //}
            // jump >:(

            //jumping -> Up key is down, height is not above 70, and can jump

            //falling -> height was above 70 -> !canJump, start falling, check if on platformn(then stop falling),
            //if not fall all the way. if !jumping and not on platform, he should fall back to origional Y

            // check if on platform -> if yes, jumpheight = 0 and canJump = true


            if (newKeyboardState.IsKeyDown(Keys.Up) && jumpHeight < 90 && canJump)
            {
                jumpDirection -= (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
                jumpHeight += 3;
            }
            if(jumpHeight >= 90)
            {
                canJump = false;
            }

            pixelRect.Y += (int)jumpDirection;
            pixelRect.X += (int)runDirection;
            boundDude.X = pixelRect.X;
            boundDude.Y = pixelRect.Y;

            if (boundDude.CollidesWith(boundPlat) || boundDude.CollidesWith(boundPlatTwo) || boundDude.CollidesWith(boundPlatThree) || boundDude.CollidesWith(boundPlatFour))
            {
                isOnPlatform = true;
            }
            else if (boundDude.CollidesWith(boundMovinPlat))
            {
                blackHole = true;
            }
            else
            {
                isOnPlatform = false;
            }
           
            

            if (isOnPlatform)
            {
                jumpHeight = 0;
                canJump = true;
            }
            else if(pixelRect.Y < groundLevel)
            {
                jumpDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
            }
            
            

            if (!canJump)
            {
                jumpHeight -= 3;
                jumpDirection += (int)(gameTime.ElapsedGameTime.TotalMilliseconds * 0.3);
            }

            if (pixelRect.Y >= groundLevel && jumpHeight <= 0)
            {
                canJump = true;
            }

            pixelRect.Y += (int)jumpDirection;
            pixelRect.X += (int)runDirection;
            boundDude.X = pixelRect.X;
            boundDude.Y = pixelRect.Y;
            if(pixelRect.Y > groundLevel)
            {
                pixelRect.Y = groundLevel;
            }

            movinPlatRect.X += platformVelocity;
            

            if (movinPlatRect.X < 0)
            {
                movinPlatRect.X = 0;
                
                platformVelocity *= -1;
            }
            if (movinPlatRect.X > GraphicsDevice.Viewport.Width - movinPlatRect.Width)
            {
                movinPlatRect.X = GraphicsDevice.Viewport.Width - movinPlatRect.Width;
                
                platformVelocity *= -1;
            }
            boundMovinPlat.X = movinPlatRect.X;

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
            if (blackHole)
            {
                pixelRect.X = 0;
                pixelRect.Y = 700 - pixelRect.Height;
                boundDude.X = pixelRect.X;
                boundDude.Y = pixelRect.Y;
                blackHole = false;
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
            spriteBatch.Draw(platform, platformRect, Color.White);
            spriteBatch.Draw(platformTwo, platTwoRect, Color.White);
            spriteBatch.Draw(movingPlatform, movinPlatRect, Color.White);
            spriteBatch.Draw(platformThree, platThreeRect, Color.White);
            spriteBatch.Draw(platformFour, platFourRect, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
