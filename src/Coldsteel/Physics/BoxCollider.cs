// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.using System;

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class BoxCollider : Collider
    {
        public Rectangle Bounds =>
            new Rectangle(
                Transform.Position.ToPoint() + BoxShape.Location,
                BoxShape.Size);

        public Rectangle BoxShape { get; set; }

        public BoxCollider() : this(0, 0, 0, 0) { }

        public BoxCollider(int originOffsetX, int originOffsetY, int width, int height)
            : this(new Rectangle(originOffsetX, originOffsetY, width, height)) { }

        public BoxCollider(Rectangle boxShape)
        {
            BoxShape = boxShape;
        }
    }
}
