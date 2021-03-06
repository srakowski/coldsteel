﻿// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Rendering;
using Coldsteel.Input;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel.Scripting
{
    /// <summary>
    /// Is responsible for updating developer defined scripts (Behaviors), and any
    /// coroutines spawned from those behaviors.
    /// </summary>
    internal class ScriptingManager : GameComponent
    {
        private ISceneManager _sceneManager;

        private IInputManager _inputManager;

        public ScriptingManager(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager = Game.Services.GetService<ISceneManager>();
            _inputManager = Game.Services.GetService<IInputManager>();
        }

        public override void Update(GameTime gameTime)
        {
            if (_sceneManager.ActiveScene == null)
                return;

            var behaviors = _sceneManager.ActiveScene.Elements.OfType<GameObject>()
                .SelectMany(go => go.Components.Where(c => c is Behavior).Select(c => c as Behavior)).ToArray();

            foreach (var behavior in behaviors)
            {
                // TODO: maybe not set these every time?
                behavior.GameTime = gameTime;
                behavior.Update();
            }

            foreach (var behavior in behaviors)
            {
                behavior.UpdateCoroutines();
            }
        }
    }
}
