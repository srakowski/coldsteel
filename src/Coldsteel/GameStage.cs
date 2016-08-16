using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class GameStage
    {
        public Color BackgroundColor { get; set; }

        private GraphicsDevice _graphicsDevice;

        private SpriteBatch _spriteBatch;

        internal void Initialize(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        internal void Render(GameTime gameTime, LayerManager layers)
        {
            _graphicsDevice.Clear(this.BackgroundColor);
            _spriteBatch.Begin();
            layers.ForEach(l => l.Render(gameTime, _spriteBatch));
            _spriteBatch.End();
        }
    }
}
