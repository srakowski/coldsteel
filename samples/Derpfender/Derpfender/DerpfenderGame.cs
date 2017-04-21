// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel;
using Derpfender.Scenes;
using Microsoft.Xna.Framework;

namespace Derpfender
{
    public class DerpfenderGame : Game
    {
        public DerpfenderGame()
        {
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Components.Add(new ColdsteelComponent(this, MainMenu.Scene, Controls.Get));
        }
    }
}
