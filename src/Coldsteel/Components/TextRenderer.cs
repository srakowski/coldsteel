using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Components
{
    public class TextRenderer : Renderer
    {
        private SpriteFont _font;

        private string _fontAssetName;

        private string _text;

        private Vector2 _origin = Vector2.Zero;

        public Color Color { get; set; } = Color.White;

        public TextRenderer(string fontAssetName, string text) 
        {
            this._fontAssetName = fontAssetName;
            this._text = text;
        }

        public override void Initialize()
        {
            _font = GameObject.Scene.Content.Load<SpriteFont>(_fontAssetName);
            //var size = _font.MeasureString(_text);
            //_origin = size / 2;
        }

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this._font,
                this._text,
                this.GameObject.Transform.Position,
                this.Color,
                this.GameObject.Transform.Rotation,
                this._origin,
                this.GameObject.Transform.Scale,
                SpriteEffects.None,
                0f);
        }
    }
}
