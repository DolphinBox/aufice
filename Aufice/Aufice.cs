using Aufice.Logistics.Scenes;
using Aufice.Objects.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
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
    public class Aufice : Game{

        public static Scene currentScene = null;

        public static ContentManager content = null;

        public static GraphicsDeviceManager graphics;

        public static Viewport viewport;

        public static float playerMoveSpeed;

        public static Player player = new Player();

        public Aufice() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Aufice.content = Content;
        }

        public static void changeScene(Scene scene) {
            content.Unload();
            //graphics.GraphicsDevice.SetRenderTarget(null);
            graphics.GraphicsDevice.Clear(Color.Aquamarine);
            
            currentScene = scene;
            scene.LoadContent();
        }

        protected override void Initialize(){
            changeScene(new MainScene("I <3n"));
            playerMoveSpeed = 8.0f;

            TouchPanel.EnabledGestures = GestureType.FreeDrag;

            //Draw a rectangle
            
            //Remember to set this to false when in-game!
            this.IsMouseVisible = true;

            // #ResizeDatWindow!
            this.Window.AllowUserResizing = true;
            //this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            viewport = graphics.GraphicsDevice.Viewport;

            base.Initialize();
        }

        protected override void LoadContent(){
            // maybe later .-.
        }

        protected override void UnloadContent(){
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime){
            currentScene.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime){
            DrawLoop.Initialize(gameTime, this.GraphicsDevice);

            base.Draw(gameTime);
        }
    }
}
