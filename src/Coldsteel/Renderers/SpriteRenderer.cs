using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Renderers
{
    public class SpriteRenderer : Renderer
    {
        private Layer _layer;

        private Texture2D _texture;

        public Texture2D Texture
        {
            get { return _texture; }
            set
            {
                _texture = value;
                _origin = new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f);
            }
        }

        private Vector2 _origin;

        public Color Color { get; set; } = Color.White;

        public SpriteRenderer(Layer layer, Texture2D texture)
        {
            _layer = layer;
            Texture = texture;
        }

        public override void Render(IGameTime gameTime)
        {
            _layer.Render(
                this.Texture,
                this.Transform.Position,
                null,
                this.Color,
                this.Transform.Rotation,
                this._origin,
                1f,
                SpriteEffects.None,
                1f);
        }
    }
}
