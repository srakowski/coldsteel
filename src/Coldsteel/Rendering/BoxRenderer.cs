// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    public class BoxRenderer : Renderer
    {
        private static Texture2D _texture2D;

        public Rectangle Shape { get; set; } = Rectangle.Empty;

        public Color Color { get; set; }

        private Rectangle DestinationRectangle =>
            new Rectangle(Transform.Position.ToPoint() + Shape.Location, Shape.Size);

        public BoxRenderer() : this(Rectangle.Empty) { }

        public BoxRenderer(int x, int y, int width, int height) 
            : this (new Rectangle(x, y, width, height))
        {
        }

        public BoxRenderer(Rectangle shape)
        {
            this.Shape = shape;
        }

        internal override void Activate(Context context)
        {
            if (_texture2D != null)
                return;

            _texture2D = new Texture2D(context.GraphicsDevice, 1, 1);
            _texture2D.SetData(new Color[] { Color.White });
        }

        internal override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture2D,
                destinationRectangle: DestinationRectangle,
                color: Color,
                rotation: Transform.Rotation,
                scale: Vector2.One * Transform.Scale);
        }
    }
}
