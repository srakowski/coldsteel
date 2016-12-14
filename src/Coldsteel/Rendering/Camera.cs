// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Rendering
{
    public class Camera : Component
    {
        private Context _context;

        internal Matrix TransformationMatrix =>
            Matrix.Identity *
            Matrix.CreateRotationZ(Transform.Rotation) *
            Matrix.CreateScale(Transform.Scale) *
            Matrix.CreateTranslation(-Transform.Position.X, -Transform.Position.Y, 0f) *
            Matrix.CreateTranslation(
                (_context.GraphicsDevice.Viewport.Width * 0.5f),
                (_context.GraphicsDevice.Viewport.Height * 0.5f),
                0f);

        public Vector2 ToWorldCoords(Vector2 coords) =>
            Vector2.Transform(coords, Matrix.Invert(this.TransformationMatrix));

        internal override void Activate(Context context)
        {
            _context = context;
        }
    }
}
