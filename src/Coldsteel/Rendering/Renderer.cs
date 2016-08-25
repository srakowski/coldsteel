using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    public abstract class Renderer : GameObjectComponent, IRenderer
    {
        public Color Color { get; set; } = Color.White;

        public byte Alpha
        {
            get { return Color.A; }
            set { this.Color = new Color(Color, value); }
        }

        public abstract void Render(GameTime gameTime, SpriteBatch spriteBatch);

        public T As<T>() where T : Renderer => this as T;
    }
}
