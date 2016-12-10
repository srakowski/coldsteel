// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Coldsteel
{
    /// <summary>
    /// Represents a slice of a frame of a rendered Scene. When a frame is 
    /// rendered each layer is rendered on top of each other beginning with
    /// the numerically lowest and ending with the numerically highest. The
    /// order of numerically equal Order values is undefined.
    /// </summary>
    public class Layer : ISceneElement
    {
        /// <summary>
        /// The Name of this layer, referenced by Renderers to identify the
        /// layer they are to render to.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Z-Order/DrawOrder. Scenes are rendered from lowest Order to highest
        /// Order, with the highest Order being rendered last and above all others.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The SpriteSortMode used within this layer.
        /// </summary>
        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;

        /// <summary>
        /// The BlendState used within this layer.
        /// </summary>
        public BlendState BlendState { get; set; } = null;

        /// <summary>
        /// The SamplerState used within this layer.
        /// </summary>
        public SamplerState SamplerState { get; set; } = null;

        /// <summary>
        /// The DepthStencilState used within this layer.
        /// </summary>
        public DepthStencilState DepthStencilState { get; set; } = null;

        /// <summary>
        /// The RasterizerState used within this layer.
        /// </summary>
        public RasterizerState RasterizerState { get; set; } = null;

        /// <summary>
        /// The Effect applied to this layer.
        /// </summary>
        public Effect Effect { get; set; } = null;

        /// <summary>
        /// The TransformationMatrix applied to this layer.
        /// </summary>
        public Matrix? TransformMatrix { get; set; } = null;

        /// <summary>
        /// Constructs a layer with the provided name and order.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="order"></param>
        public Layer(string name, int order)
        {
            this.Name = name;
            this.Order = order;
        }

        internal void Render(SpriteBatch spriteBatch, IEnumerable<Renderer> renderers, Camera camera = null)
        {
            var matrix = (camera?.Transform.TransformationMatrix ?? Matrix.Identity) *
                (TransformMatrix ?? Matrix.Identity);

            spriteBatch.Begin(SpriteSortMode, BlendState, SamplerState,
                DepthStencilState, RasterizerState, Effect, matrix);

            foreach (var renderer in renderers)
                renderer.Render(spriteBatch);

            spriteBatch.End();
        }
    }
}
