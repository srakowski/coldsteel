using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Renderers
{
    public class SpriteRenderer : Renderer
    {
        public Layer Layer { get; set; }

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

        public byte Alpha
        {
            get { return Color.A; }
            set { Color = new Color(this.Color, value); }
        }

        public SpriteRenderer(Layer layer, Texture2D texture)
        {
            Layer = layer;
            Texture = texture;
        }

        public override void Render(IGameTime gameTime)
        {
            Layer.Render(
                this.Texture,
                this.Transform.Position,
                null,
                this.Color,
                this.Transform.Rotation,
                this._origin,
                this.Transform.Scale,
                SpriteEffects.None,
                1f);
        }
    }
}
