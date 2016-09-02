using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Rendering
{
    public class TextRenderer : Renderer
    {
        private SpriteFont SpriteFont { get; set; }

        public string Text { get; set; }

        public TextRenderer(SpriteFont spriteFont, string text)
        {
            SpriteFont = spriteFont;
            Text = text;
        }

        public override void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.SpriteFont,
                this.Text,
                this.Transform.Position,
                this.Color
                );
        }
    }
}
