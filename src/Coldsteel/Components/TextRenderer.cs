// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Components
{
    /// <summary>
    /// Renders the provided Text to a Scene Layer using the provided SpriteFont.
    /// </summary>
    public class TextRenderer : Renderer
    {
        private Vector2 _origin = Vector2.Zero;

        /// <summary>
        /// The SpriteFont to render the Text in.
        /// </summary>
        public SpriteFont SpriteFont { get; set; }

        /// <summary>
        /// The Text to render.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The Color of the Text.
        /// </summary>
        public Color Color { get; set; } = Color.White;

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.SpriteFont,
                this.Text,
                this.Transform.Position,
                this.Color,
                this.Transform.Rotation,
                this._origin,
                this.Transform.Scale,
                SpriteEffects.None,
                0f);
        }
    }
}
