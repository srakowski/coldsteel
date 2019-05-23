// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class Camera : Component
    {
        public bool Enabled;

        public Vector2 ToWorldCoords(Vector2 coords) =>
            Vector2.Transform(coords, Matrix.Invert(TransformationMatrix));

        internal Matrix TransformationMatrix =>
            Matrix.Identity *
            Matrix.CreateRotationZ(Entity.Rotation) *
            Matrix.CreateScale(Entity.Scale) *
            Matrix.CreateTranslation(-Entity.Position.X, -Entity.Position.Y, 0f) *
            Matrix.CreateTranslation(
                (Engine.Game.GraphicsDevice.Viewport.Width * 0.5f),
                (Engine.Game.GraphicsDevice.Viewport.Height * 0.5f),
                0f);

        private protected override void Activated()
        {
            Engine.SpriteSystem.AddCamera(Scene, this);
        }

        private protected override void Deactivated()
        {
            Engine.SpriteSystem.RemoveCamera(Scene, this);
        }
    }
}
