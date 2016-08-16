using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    public class SpriteRenderer : Renderer
    {
        private Texture2D _image;

        private Vector2 _origin;

        public SpriteRenderer(Texture2D image)
        {
            _image = image;
            _origin = new Vector2(image.Width * 0.5f, image.Height * 0.5f);
        }

        public override void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this._image,
                this.Transform.Position,
                null,
                this.Color,
                this.Transform.Rotation,
                _origin,
                1f,
                SpriteEffects.None,
                0f
                );
        }
    }
}
