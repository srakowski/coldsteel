// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering2D
{
    /// <summary>
    /// A Texture-based sprite.
    /// </summary>
    public class TextureSprite : Sprite
    {
        public ContentReference<Texture2D> Texture { get; set; }
    }
}
