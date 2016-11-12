using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufice.Logistics.Scenes
{
    class MainScene : Scene{
        Texture2D texture;
        Vector2 position;
        Vector2 position2;
        Texture2D play_button;
        Texture2D background;
        Texture2D background2;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;
        MouseState currentMouseState;
        MouseState previousMouseState;

        // Audio objects
        SoundEffect soundEffect;
        SoundEffectInstance soundInstance;

        //Font Stuff
        SpriteFont font;
        SpriteFont fontBig;

        public MainScene(String Name) {
            this.name = Name;
        }
        public override void Enable(GameTime gameTime, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch){
            Color bgcolor = new Color(173, 230, 255);
            graphicsDevice.Clear(bgcolor);

            // TODO: Add your drawing code here
            spriteBatch.End();
            //Things drawn on screen are layered from top to bottom from where they are drawn here.
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(-Aufice.viewport.Width, -Aufice.viewport.Height - 120)); //Layering some backgrounds
            spriteBatch.Draw(background2, position2);

            spriteBatch.Draw(texture, destinationRectangle: new Rectangle(0, 0, 60, 60));
            spriteBatch.Draw(play_button, destinationRectangle: new Rectangle(325, 175, 150, 150));
            spriteBatch.DrawString(font, "FPS:" + (1000 / gameTime.ElapsedGameTime.Milliseconds), new Vector2(725.0f, 20.0f), Color.White);
            spriteBatch.DrawString(font, "Play Aufice!", new Vector2(360.0f, 185.0f), Color.LightCyan);
            spriteBatch.DrawString(fontBig, "Aufice", new Vector2(350.0f, 50.0f), Color.LightCyan);
            Aufice.player.Draw(spriteBatch);
        }
        public override void LoadContent() {
            texture = Aufice.content.Load<Texture2D>("logo");

            play_button = Aufice.content.Load<Texture2D>("appbar.control.play");
            background = Aufice.content.Load<Texture2D>("pixel_background");
            background2 = Aufice.content.Load<Texture2D>("appbar.cloud");

            Vector2 playerPosition = new Vector2(Aufice.graphics.GraphicsDevice.Viewport.TitleSafeArea.X, Aufice.graphics.GraphicsDevice.Viewport.TitleSafeArea.Y + Aufice.graphics.GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            
            Texture2D d = Aufice.content.Load<Texture2D>("appbar.cursor.default");

            Aufice.player.Initialize(d, playerPosition);

            //Initalize Sounds
            soundEffect = Aufice.content.Load<SoundEffect>("intro");
            soundInstance = soundEffect.CreateInstance();

            //Set Volume
            soundInstance.Volume = 0.5F;

            //Play sounds
            soundInstance.Play();

            // Put the name of the font
            font = Aufice.content.Load<SpriteFont>("Font1");
            fontBig = Aufice.content.Load<SpriteFont>("FontBig");
        }
        public override void Update(GameTime gameTime) {
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            UpdatePlayer(gameTime);

            //Update rectangle position
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
           
               //Exit();

             position.X += 1;
             if (position.X > Aufice.graphics.GraphicsDevice.Viewport.Width)
                 position.X = 0;

             position2.X += 1f;
             if (position2.X > Aufice.graphics.GraphicsDevice.Viewport.Width)
                 position2.X = 0;

        }
        //Updates the player constantly
        private void UpdatePlayer(GameTime gameTime)
        {
            // Get Thumbstick Controls
            Aufice.player.Position.X += currentGamePadState.ThumbSticks.Left.X * Aufice.playerMoveSpeed;
            Aufice.player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * Aufice.playerMoveSpeed;

            // Use the Keyboard / Dpad
            if (currentKeyboardState.IsKeyDown(Keys.A) || currentGamePadState.DPad.Left == ButtonState.Pressed)
            {
                Aufice.player.Position.X -= Aufice.playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.D) || currentGamePadState.DPad.Right == ButtonState.Pressed)
            {
                Aufice.player.Position.X += Aufice.playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.W) || currentGamePadState.DPad.Up == ButtonState.Pressed)
            {
                Aufice.player.Position.Y -= Aufice.playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) || currentGamePadState.DPad.Down == ButtonState.Pressed)
            {
                Aufice.player.Position.Y += Aufice.playerMoveSpeed;
            }

            Aufice.player.Position.X = MathHelper.Clamp(Aufice.player.Position.X, 0, Aufice.graphics.GraphicsDevice.Viewport.Width - Aufice.player.Width);

            Aufice.player.Position.Y = MathHelper.Clamp(Aufice.player.Position.Y, 0, Aufice.graphics.GraphicsDevice.Viewport.Height - Aufice.player.Height);


        }
    }
}
