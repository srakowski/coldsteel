﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Rendering;

namespace Coldsteel
{
    public class Layer
    {
        private List<IRenderer> _renderers = new List<IRenderer>();

        private string _key;

        public string Key => _key;

        private int _sortIndex;

        public int SortIndex => _sortIndex;

        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;

        public Layer SetSpriteSortMode(SpriteSortMode spriteSortMode)
        {
            SpriteSortMode = spriteSortMode;
            return this;
        }

        public BlendState BlendState { get; set; } = null;

        public Layer SetBlendState(BlendState blendState)
        {
            BlendState = blendState;
            return this;
        }

        public SamplerState SamplerState { get; set; } = null;

        public Layer SetSamplerState(SamplerState samplerState)
        {
            SamplerState = samplerState;
            return this;
        }

        public bool FixedToCamera { get; set; } = false;

        public Layer SetFixedToCamera(bool value)
        {
            FixedToCamera = value;
            return this;
        }

        public Layer(string key, int sortIndex, bool fixedToCamera = false)
        {
            this._key = key;
            this._sortIndex = sortIndex;
            this.FixedToCamera = fixedToCamera;
        }

        internal void Render(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            var matrix = FixedToCamera ? (Matrix?)null : camera.TransformationMatrix;
            spriteBatch.Begin(SpriteSortMode, BlendState, SamplerState, null, null, null, matrix);
            _renderers.ForEach(r => r.Render(gameTime, spriteBatch));
            spriteBatch.End();
        }

        internal void AddRenderer(IRenderer renderer)
        {
            _renderers.Add(renderer);
        }

        internal void RemoveRenderer(IRenderer renderer)
        {
            _renderers.Remove(renderer);
        }
    }
}
