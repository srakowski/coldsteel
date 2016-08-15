using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal class MonoGameImpl : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;

        private GameStateManager State { get; set; }

        public MonoGameImpl()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        protected override void Update(GameTime gameTime)
        {
            State?.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            State?.Draw(gameTime);
        }
    }
}
