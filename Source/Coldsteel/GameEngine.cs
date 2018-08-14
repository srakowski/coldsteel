// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    /// <summary>
    /// Primary entry point for the Coldsteel GameEngine.
    /// </summary>
    public class GameEngine : GameComponent
    {
        public GameEngine(Game game) : base(game)
        {
            Game.Components.Add(new Rendering2D.SpriteRenderingSystem(game));
        }
    }
}
