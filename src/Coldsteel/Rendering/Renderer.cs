// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    /// <summary>
    /// Derived components are responsible for rendering content to a Layer.
    /// </summary>
    public abstract class Renderer : Component
    {
        /// <summary>
        /// The name of the Layer this Renderer will be rendered to.
        /// </summary>
        public string Layer { get; set; }

        internal abstract void Render(SpriteBatch spriteBatch);
    }
}
