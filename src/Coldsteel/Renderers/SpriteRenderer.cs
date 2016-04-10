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

        public Texture2D Texture { get; set; }

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
                this.Color
                );
        }
    }
}
