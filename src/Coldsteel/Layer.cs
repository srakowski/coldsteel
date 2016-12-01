using Coldsteel.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class Layer
    {
        public string Name { get; private set; }

        public bool IsDefault => Name == "default";

        public int Order { get; set; }

        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;

        public BlendState BlendState { get; set; } = null;

        public SamplerState SamplerState { get; set; } = null;

        public DepthStencilState DepthStencilState { get; set; } = null;

        public RasterizerState RasterizerState { get; set; } = null;

        public Effect Effect { get; set; } = null;

        public Matrix? TransformMatrix { get; set; } = null;

        public Layer(string name, int depth)
        {
            this.Name = name;
            this.Order = depth;
        }

        internal void Render(SpriteBatch spriteBatch, IEnumerable<Renderer> renderers)
        {
            spriteBatch.Begin(SpriteSortMode, BlendState, SamplerState,
                DepthStencilState, RasterizerState, Effect, TransformMatrix);

            foreach (var renderer in renderers)
                renderer.Render(spriteBatch);

            spriteBatch.End();
        }
    }
}
