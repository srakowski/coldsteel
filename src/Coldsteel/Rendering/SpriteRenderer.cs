using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    public class SpriteRenderer : Renderer
    {
        public Texture2D Image { get; set; }

        private Vector2 _origin;

        public SpriteRenderer(Texture2D image)
        {
            Image = image;
            _origin = new Vector2(image.Width * 0.5f, image.Height * 0.5f);
        }

        public override void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.Image,
                this.Transform.Position,
                null,
                new Color(this.Color, Alpha),
                this.Transform.Rotation,
                _origin,
                1f,
                SpriteEffects.None,
                0f
                );
        }
    }
}
