// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.using System;

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class BoxCollider : Component
    {
        public Rectangle BoundingBox =>
            new Rectangle(
                Transform.Position.ToPoint() - LocalBoundingBox.Location,
                LocalBoundingBox.Size);

        public Rectangle LocalBoundingBox { get; set; }

        public BoxCollider() { }

        public BoxCollider(Rectangle boundingBox)
        {
            LocalBoundingBox = boundingBox;
        }
    }
}
