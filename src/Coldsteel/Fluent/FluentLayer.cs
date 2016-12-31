// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Fluent
{
    /// <summary>
    /// Defines a Fluent interface for building Layers.
    /// </summary>
    public static class FluentLayer
    {
        public static Layer SetOrder(this Layer self, int order)
        {
            self.Order = order;
            return self;
        }

        public static Layer SetSpriteSortMode(this Layer self, SpriteSortMode value)
        {
            self.SpriteSortMode = value;
            return self;
        }

        public static Layer SetBlendState(this Layer self, BlendState value)
        {
            self.BlendState = value;
            return self;
        }

        public static Layer SetSamplerState(this Layer self, SamplerState value)
        {
            self.SamplerState = value;
            return self;
        }

        public static Layer SetDepthStencilState(this Layer self, DepthStencilState value)
        {
            self.DepthStencilState = value;
            return self;
        }

        public static Layer SetRasterizerState(this Layer self, RasterizerState value)
        {
            self.RasterizerState = value;
            return self;
        }

        public static Layer SetEffect(this Layer self, Effect value)
        {
            self.Effect = value;
            return self;
        }

        public static Layer SetMatrix(this Layer self, Matrix value)
        {
            self.TransformMatrix = value;
            return self;
        }
    }
}
