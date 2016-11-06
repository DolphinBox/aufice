using Aufice.Objects.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
//using System;


/*
 * (c) 2016 EstiNet
 * Aufice is a 2.5D Puzzle Platformer, centered on a world that expands as you unlock the world around.
 * Built on XNA/MonoGame.
 */


namespace Aufice
{
    /// <summary>
    /// Aufice. An experimental game.
    /// </summary>
    public class Aufice : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Texture2D play_button;

        // Audio objects
        SoundEffect soundEffect;

        /* 
        Input Processes
        */

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;
        MouseState currentMouseState;
        MouseState previousMouseState;

        SoundEffectInstance soundInstance;

        float playerMoveSpeed;

        Player player;

        //Font Stuff
        SpriteFont font;


        public Aufice() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize(){
            player = new Player();
            playerMoveSpeed = 8.0f;

            TouchPanel.EnabledGestures = GestureType.FreeDrag;

            //Draw a rectangle
            
            //Remember to set this to false when in-game!
            this.IsMouseVisible = true;

            // #ResizeDatWindow!
            this.Window.AllowUserResizing = true;
            //this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent(){
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = this.Content.Load<Texture2D>("logo");

            play_button = this.Content.Load<Texture2D>("appbar.control.play");

            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

            player.Initialize(Content.Load<Texture2D>("Seshpenguin"), playerPosition);


            //if(texture.)

            //Initalize Sounds
            //soundfile = TitleContainer.OpenStream(@"Content\tx0_fire1.wav");
            soundEffect = Content.Load<SoundEffect>("intro");
            soundInstance = soundEffect.CreateInstance();

            //Set Volume
            soundInstance.Volume = 0.5F;

            //Play sounds
            soundInstance.Play();

            // Put the name of the font
            font = this. Content.Load<SpriteFont>("Font1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent(){
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime){
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            UpdatePlayer(gameTime);

            //Update rectangle position
            if (IsActive){
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                base.Update(gameTime);
            }


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime){
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Draw the rectangle
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle: new Rectangle(0, 0, 60, 60));
            spriteBatch.Draw(play_button, destinationRectangle: new Rectangle(300, 300, 150, 150));
            spriteBatch.DrawString(font, "FPS:" + (1000 / gameTime.ElapsedGameTime.Milliseconds), new Vector2(10.0f, 20.0f), Color.White);

            spriteBatch.End();

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        
        //Updates the player constantly
        private void UpdatePlayer(GameTime gameTime){
            // Get Thumbstick Controls
            player.Position.X += currentGamePadState.ThumbSticks.Left.X * playerMoveSpeed;
            player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * playerMoveSpeed;

            // Use the Keyboard / Dpad
            if (currentKeyboardState.IsKeyDown(Keys.A) || currentGamePadState.DPad.Left == ButtonState.Pressed){
                player.Position.X -= playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.D) || currentGamePadState.DPad.Right == ButtonState.Pressed){
                player.Position.X += playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.W) || currentGamePadState.DPad.Up == ButtonState.Pressed){
                player.Position.Y -= playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) || currentGamePadState.DPad.Down == ButtonState.Pressed){
                player.Position.Y += playerMoveSpeed;
            }

            player.Position.X = MathHelper.Clamp(player.Position.X, 0, GraphicsDevice.Viewport.Width - player.Width);

            player.Position.Y = MathHelper.Clamp(player.Position.Y, 0, GraphicsDevice.Viewport.Height - player.Height);
        }

    }
}
