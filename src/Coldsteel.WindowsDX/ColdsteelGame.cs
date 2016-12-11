// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class ColdsteelGame : Game
    {
        GraphicsDeviceManager _graphics;

        public ColdsteelGame()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                // TODO: make this configurable
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720
            };
            Content.RootDirectory = "Content";
            Components.Add(new Bootstrapper(this));
        }
    }
}
