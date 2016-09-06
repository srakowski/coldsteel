using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public sealed class GameStage
    {
        public Color BackgroundColor { get; set; }

        public float Width => _graphicsDevice.Viewport.Width;

        public float Height => _graphicsDevice.Viewport.Height;

        private GraphicsDevice _graphicsDevice;

        private SpriteBatch _spriteBatch;

        internal void Initialize(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        internal void Render(GameTime gameTime, Camera camera, LayerManager layers)
        {
            _graphicsDevice.Clear(this.BackgroundColor);
            layers.ForEach(l => l.Render(gameTime, _spriteBatch, camera));
        }
    }
}
