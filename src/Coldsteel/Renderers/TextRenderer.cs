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

        public SpriteFont Font
        {
            get { return _font; }
            set
            {
                _font = value;
                UpdateOrigin();
            }
        }

        private Vector2 _origin = Vector2.Zero;

        private string _text = String.Empty;

        public String Text
        {
            get { return _text; }
            set
            {
                _text = value;
                UpdateOrigin();
            }
        }

        public Color Color { get; set; } = Color.White;

        public byte Alpha
        {
            get { return Color.A; }
            set { Color = new Color(this.Color, value); }
        }

        public TextRenderer(Layer layer, SpriteFont font, string text = "")
            : base(layer)
        {
            this.Font = font;
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


        private void UpdateOrigin()
        {
            if (Font == null)
            {
                _origin = Vector2.Zero;
                return;
            }

            var textDim = Font.MeasureString(this.Text);
            _origin = textDim / 2f;
        }
    }
}
