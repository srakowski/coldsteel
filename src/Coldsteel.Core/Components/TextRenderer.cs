using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Core.Components
{
    public class TextRenderer : Renderer
    {
        private Vector2 _origin = Vector2.Zero;

        public SpriteFont SpriteFont { get; set; }

        public string Text { get; set; }

        public Color Color { get; set; } = Color.White;

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.SpriteFont,
                this.Text,
                this.GameObject.Transform.Position,
                this.Color,
                this.GameObject.Transform.Rotation,
                this._origin,
                this.GameObject.Transform.Scale,
                SpriteEffects.None,
                0f);
        }
    }
}
