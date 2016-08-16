using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    public abstract class Renderer : GameObjectComponent
    {
        public Color Color { get; set; } = Color.White;

        public abstract void Render(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
