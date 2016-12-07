// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    /// <summary>
    /// Used to register Components and Services on the provided 
    /// Game Instance. This plugs Coldteel into the MonoGame Game.
    /// </summary>
    public static class Engine
    {
        public static void Attach(Game game)
        {
            var sceneManager = new SceneManager(game);
            game.Components.Add(sceneManager);
            var inputManager = new InputManager(game);
            game.Components.Add(inputManager);
            var scriptingManager = new ScriptingManager(game);
            game.Components.Add(scriptingManager);
            var renderingManager = new RenderingManager(game);
            game.Components.Add(renderingManager);
        }
    }
}
