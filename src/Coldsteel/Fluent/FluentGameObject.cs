// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Fluent
{
    /// <summary>
    /// Defines a Fluent interface for building GameObjects.
    /// </summary>
    public static class FluentGameObject
    {
        public static GameObject SetName(this GameObject self, string name)
        {
            self.Name = name;
            return self;
        }

        public static GameObject SetPosition(this GameObject self, float x, float y)
        {
            self.Transform.LocalPosition = new Vector2(x, y);
            return self;
        }

        public static GameObject SetPosition(this GameObject self, Vector2 position)
        {
            self.Transform.LocalPosition = position;
            return self;
        }

        public static GameObject SetRotation(this GameObject self, float rotationInRadians)
        {
            self.Transform.LocalRotation = rotationInRadians;
            return self;
        }

        public static GameObject SetRotationInDegrees(this GameObject self, float rotationInDegrees)
        {
            self.Transform.Rotation = MathHelper.ToRadians(rotationInDegrees);
            return self;
        }

        public static GameObject SetScale(this GameObject self, float scale)
        {
            self.Transform.Scale = scale;
            return self;
        }

        public static GameObject SetParent(this GameObject self, GameObject gameObject)
        {
            self.Transform.SetParent(gameObject.Transform);
            return self;
        }
    }
}
