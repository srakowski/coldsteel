using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal class MonoGameImpl : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;

        internal GameStateManager State { get; set; }

        public MonoGameImpl()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            State?.Initialize(this.GraphicsDevice);
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
