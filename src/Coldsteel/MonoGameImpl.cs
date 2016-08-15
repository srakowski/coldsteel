using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal class MonoGameImpl : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;

        public MonoGameImpl()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }
    }
}
