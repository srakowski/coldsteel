using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Components
{
    public class SpriteRenderer : Renderer
    {
        private Texture2D _texture;

        private Vector2 _origin;

        private string _textureAssetName;

        public Color Color { get; set; } = Color.White;

        public SpriteRenderer(string textureAssetName)
        {
            this._textureAssetName = textureAssetName;
        }

        public override void Initialize()
        {
            this._texture = GameObject.Scene.Content.Load<Texture2D>(_textureAssetName);
            this._origin = new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f);
        }

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this._texture,
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
