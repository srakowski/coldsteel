// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Coldsteel.Rendering
{
    /// <summary>
    /// Renders a Sprite to a Scene Layer.
    /// </summary>
    public class SpriteRenderer : Renderer
    {
        private Vector2 _origin;

        private string _textureAssetName;

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
        /// The origin used to position the texture. If none is provided 
        /// the center of the texture is used.
        /// </summary>
        public Vector2? Origin { get; set; }

        /// <summary>
        /// Color to tint the Sprite, White is none.
        /// </summary>
        public Color Color { get; set; } = Color.White;

        /// <summary>
        /// Get or sets the sprite effects;
        /// </summary>
        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;

        /// <summary>
        /// Constructs an empty SpriteRenderer.
        /// </summary>
        public SpriteRenderer() { }

        /// <summary>
        /// Constructs a SpriteRenderer with the textureAsset that will be loaded
        /// during the activation of the GameObject.
        /// </summary>
        /// <param name="textureAssetName"></param>
        public SpriteRenderer(string textureAssetName)
        {
            _textureAssetName = textureAssetName;
        }

        internal override void Activate(Context context) =>
            Texture2D = context.Content.Load<Texture2D>(_textureAssetName);

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.Texture2D,
                this.Transform.Position,
                null,
                this.Color,
                this.Transform.Rotation,
                this.Origin ?? this._origin,
                this.Transform.Scale,
                this.SpriteEffects,
                0f);
        }
    }
}
