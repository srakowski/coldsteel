// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Components;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel
{
    /// <summary>
    /// Is responsible for updating developer defined scripts (Behaviors), and any
    /// coroutines spawned from those behaviors.
    /// </summary>
    internal class ScriptingManager : GameComponent
    {
        private ISceneManager _sceneManager;

        public ScriptingManager(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager = Game.Services.GetService<ISceneManager>();
        }

        public override void Update(GameTime gameTime)
        {
            if (_sceneManager.ActiveScene == null)
                return;

            var behaviors = _sceneManager.ActiveScene.GameObjects.SelectMany(go => go.Components.Where(c => c is Behavior).Select(c => c as Behavior));

            foreach (var behavior in behaviors)
            {
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
