using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aufice.Logistics.Scenes
{
    public class Scene {
        protected String name = "";
        public Scene() { }
        //AUtomated Implementation
        public Scene(String Name) {

        }
        public virtual void Enable(GameTime gameTime, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch) {

        }
        public virtual void LoadContent() {

        }
        public virtual void Update(GameTime gameTime) {
        }
    }
}
