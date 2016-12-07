// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Coldsteel.Components
{
    /// <summary>
    /// Renders the provided Text to a Scene Layer using the provided SpriteFont.
    /// </summary>
    public class TextRenderer : Renderer
    {
        private Vector2 _origin = Vector2.Zero;

        private string _spriteFontAssetName;

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

        /// <summary>
        /// Constructs an empty TextRenderer.
        /// </summary>
        public TextRenderer() { }

        /// <summary>
        /// Constructs a TextRenderer with the assetName of the SpriteFont that will be 
        /// loaded during the activation of the GameObject, and the initial text.
        /// </summary>
        /// <param name="textureAssetName"></param>
        public TextRenderer(string spriteFontAssetName, string text)
        {
            _spriteFontAssetName = spriteFontAssetName;
            Text = text;
        }

        internal override void Activate(ContentManager content) =>
            SpriteFont = content.Load<SpriteFont>(_spriteFontAssetName);

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
