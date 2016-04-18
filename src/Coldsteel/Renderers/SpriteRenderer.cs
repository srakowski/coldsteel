using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Renderers
{
    public class SpriteRenderer : Renderer
    {
        private Texture2D _texture;

        public Texture2D Texture
        {
            get { return _texture; }
            set
            {
                _texture = value;
                _spriteCenter = new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f);
            }
        }

        private Vector2 _spriteCenter;

        public Color Color { get; set; } = Color.White;

        public byte Alpha
        {
            get { return Color.A; }
            set { Color = new Color(this.Color, value); }
        }

        public int LayerDepth { get; set; } = 100;

        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;

        public Rectangle? DestinationRectangle { get; set; } = null;

        public SpriteRenderer(Layer layer, Texture2D texture)
            : base(layer)
        {
            Layer = layer;
            Texture = texture;
        }

        public override void Render(IGameTime gameTime)
        {
            Layer.Render(
                this.Texture,
                this.Transform.Position,
                this.DestinationRectangle,
                this.Color,
                this.Transform.Rotation,
                this._spriteCenter,
                this.Transform.Scale,
                SpriteEffects,
                LayerDepth / 100f);
        }
    }
}
