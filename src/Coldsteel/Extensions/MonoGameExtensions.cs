using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Extensions
{
    public static class MonoGameExtensions
    {
        public static Vector2 Midpoint(this Texture2D texture) => new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
    }
}
