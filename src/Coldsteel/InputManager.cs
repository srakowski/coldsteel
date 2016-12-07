// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Controls;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    /// <summary>
    /// This component is responsible for ensuring input states are 
    /// updated between frames.
    /// </summary>
    internal class InputManager : GameComponent
    {
        public InputManager(Game game) : base(game) { }

        public override void Update(GameTime gameTime)
        {
            Input.Update(gameTime);
        }
    }
}
