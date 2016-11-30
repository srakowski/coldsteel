using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class Layer
    {
        private string _name;

        private int _depth;

        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;

        public BlendState BlendState { get; set; } = null;

        public SamplerState SamplerState { get; set; } = null;

        public DepthStencilState DepthStencilState { get; set; } = null;

        public RasterizerState RasterizerState { get; set; } = null;

        public Effect Effect { get; set; } = null;

        public Matrix? TransformMatrix { get; set; } = null;

        public Layer(string name, int depth)
        {
            this._name = name;
            this._depth = depth;
        }
    }
}
