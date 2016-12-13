// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Rendering
{
    public class Camera : Component
    {
        public Vector2 ToWorldCoords(Vector2 coords) =>
            Vector2.Transform(coords, Matrix.Invert(Transform.TransformationMatrix));
    }
}
