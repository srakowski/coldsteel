using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Renderers
{
    public class TextRenderer : Renderer
    {
        private SpriteFont _font;

        private Vector2 _origin = Vector2.Zero;

        public String Text { get; set; }

        public Color Color { get; set; } = Color.White;

        public byte Alpha
        {
            get { return Color.A; }
            set { Color = new Color(this.Color, value); }
        }

        public TextRenderer(Layer layer, SpriteFont font, string text = "")
            : base(layer)
        {
            this._font = font;
            this.Text = text;
        }

        public override void Render(IGameTime gameTime)
        {
            Layer.RenderText(
                _font,
                Text,
                this.Transform.Position,
                this.Color,
                this.Transform.Rotation,
                this._origin,
                this.Transform.Scale,
                SpriteEffects.None,
                1f);
        }
    }
}
