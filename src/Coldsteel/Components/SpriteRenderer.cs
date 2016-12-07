// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Components
{
    /// <summary>
    /// Renders a Sprite to a Scene Layer.
    /// </summary>
    public class SpriteRenderer : Renderer
    {
        private Vector2 _origin;

        private Texture2D _texture2D;

        /// <summary>
        /// The Texture2D content used to compose the Sprite.
        /// </summary>
        public Texture2D Texture2D
        {
            get { return _texture2D; }
            set
            {
                _texture2D = value;
                if (_texture2D != null)
                    this._origin = new Vector2(Texture2D.Width * 0.5f, Texture2D.Height * 0.5f);
            }
        }

        /// <summary>
        /// Color to tint the Sprite, White is none.
        /// </summary>
        public Color Color { get; set; } = Color.White;

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.Texture2D,
                this.Transform.Position,
                null,
                this.Color,
                this.Transform.Rotation,
                this._origin,
                this.Transform.Scale,
                SpriteEffects.None,
                0f);
        }
    }
}
