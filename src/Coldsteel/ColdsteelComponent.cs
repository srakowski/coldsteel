// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Coldsteel
{
    public class ColdsteelComponent : GameComponent
    {
        public ColdsteelComponent(Game game, Func<Scene> openingScene, Func<IEnumerable<IControl>> controls) : base(game)
        {
            game.Components.Add(new SceneManager(game, openingScene));
            game.Components.Add(new PhysicsManager(game));
            game.Components.Add(new InputManager(game, controls));
            game.Components.Add(new ScriptingManager(game));
            game.Components.Add(new RenderingManager(game));
        }
    }
}
