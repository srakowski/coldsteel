// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Derpfender
{
    class DerpfenderGame : Game
    {
        private GraphicsDeviceManager _graphics;

        public DerpfenderGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Components.Add(new Coldsteel.Bootstrapper(this));
        }
    }
}
