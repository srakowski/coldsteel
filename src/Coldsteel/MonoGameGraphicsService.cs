using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel
{
    internal class MonoGameGraphicsService : IGraphicsService
    {
        private Game _game;

        public MonoGameGraphicsService(Game game)
        {
            this._game = game;
        }

        public Viewport DefaultViewport
        {
            get
            {
                return _game.GraphicsDevice.Viewport;
            }
        }

        public void Clear(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }
    }
}