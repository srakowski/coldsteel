using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Core.Components
{
    public class SpriteRenderer : Renderer
    {
        private Vector2 _origin;

        public Texture2D Texture2D { get; set; }

        public Color Color { get; set; } = Color.White;

        public override void Initialize()
        {
            this._origin = new Vector2(Texture2D.Width * 0.5f, Texture2D.Height * 0.5f);
        }

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.Texture2D,
                this.GameObject.Transform.Position,
                null,
                this.Color,
                this.GameObject.Transform.Rotation,
                this._origin,
                this.GameObject.Transform.Scale,
                SpriteEffects.None,
                0f);
        }
    }
}
