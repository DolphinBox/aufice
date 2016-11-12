using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aufice;

namespace Aufice.Logistics.Scenes
{
    static class DrawLoop{
        public static GameTime Initialize(GameTime gameTime, GraphicsDevice gd) {
            SpriteBatch spriteBatch = new SpriteBatch(gd);
            spriteBatch.Begin();
            Aufice.currentScene.Enable(gameTime, gd, spriteBatch);
            spriteBatch.End();
            return gameTime;
        }
    }
}
