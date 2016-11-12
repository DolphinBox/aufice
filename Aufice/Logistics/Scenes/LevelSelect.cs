using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufice.Logistics.Scenes
{
    class LevelSelect : Scene {
        Texture2D texture;
        Texture2D background;

        public LevelSelect(String Name) {
              this.name = Name;
        }
        public override void LoadContent() {
            texture = Aufice.content.Load<Texture2D>("logo");
            background = Aufice.content.Load<Texture2D>("pixel_background");
        }
        public override void Enable(GameTime gameTime, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch) {
            spriteBatch.Draw(background, new Vector2(-Aufice.viewport.Width, -Aufice.viewport.Height - 120));
            spriteBatch.Draw(texture, destinationRectangle: new Rectangle(0, 0, 60, 60));
        }
        
        public override void Update(GameTime gameTime) {
            
        }

    }

    
}
