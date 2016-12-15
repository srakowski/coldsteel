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
        /// All Scenes have at least 1 layer with this name set draw at order 0. To
        /// draw content behind this layer add a layer with an Order less than 0. To
        /// draw above this layer add a layer with an Order greater than 0.
        /// </summary>
        public static string DefaultLayerName { get; } = "default";

        /// <summary>
        /// The name of the Layer this Renderer will be rendered to.
        /// </summary>
        public string Layer { get; set; }

        internal abstract void Render(SpriteBatch spriteBatch);
    }
}
