using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Extensions;

namespace Coldsteel.Rendering
{
    public class SpriteRenderer : Renderer
    {
        public Texture2D Image { get; set; }

        public Vector2 Origin { get; protected set; }

        public Rectangle? SourceRectangle { get; set; }

        public SpriteRenderer(Texture2D image)
        {
            Image = image;
            Origin = image.GetMidpoint();
        }

        public override void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.Image,
                this.Transform.Position,
                this.SourceRectangle,
                new Color(this.Color, Alpha),
                this.Transform.Rotation,
                Origin,
                1f,
                SpriteEffects.None,
                0f
                );
        }
    }
}
