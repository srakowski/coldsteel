// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Coldsteel
{
    public class SpriteLayer
    {
        public string Name;

        public int Depth;

        public bool FixToCamera;

        public SpriteSortMode SpriteSortMode;

        public BlendState BlendState;

        public SamplerState SamplerState;

        public DepthStencilState DepthStencilState;

        public RasterizerState RasterizerState;

        public Effect Effect;

        public Matrix? TransformMatrix;

        public SpriteLayer() { }

        public SpriteLayer(string name)
        {
            Name = name;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, IEnumerable<Sprite> sprites)
        {
            var cameraMatrix = camera != null && !FixToCamera
                ? camera.TransformationMatrix
                : Matrix.Identity;

            var transformMatrix = TransformMatrix ?? Matrix.Identity;

            spriteBatch.Begin(SpriteSortMode, BlendState, SamplerState, DepthStencilState, RasterizerState, Effect, transformMatrix * cameraMatrix);

            foreach (var sprite in sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
