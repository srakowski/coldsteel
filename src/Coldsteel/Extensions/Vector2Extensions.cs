// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 ShiftX(this Vector2 self, float x) =>
            self + new Vector2(x, 0);

        public static Vector2 ShiftY(this Vector2 self, float y) =>
            self + new Vector2(0, y);

        public static Vector2 Shift(this Vector2 self, float x, float y) =>
            self + new Vector2(x, y);
    }
}
