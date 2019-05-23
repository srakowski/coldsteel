// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class BoxCollider : Collider
    {
        public BoxCollider(float width, float height)
            : base(new Polygon(new[]
            {
                new Vector2(-(width * 0.5f), -(height * 0.5f)),
                new Vector2((width * 0.5f), -(height * 0.5f)),
                new Vector2((width * 0.5f), (height * 0.5f)),
                new Vector2(-(width * 0.5f), (height * 0.5f))
            }))

        {
        }
    }
}
