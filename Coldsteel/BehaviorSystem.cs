// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Coldsteel
{
    internal class BehaviorSystem : GameComponent
    {
        private readonly Dictionary<Scene, List<Behavior>> _behaviorsByScene = new Dictionary<Scene, List<Behavior>>();

        private readonly Engine _engine;

        public BehaviorSystem(Game game, Engine engine) : base(game)
        {
            _engine = engine;
            game.Components.Add(this);
        }

        internal void AddBehavior(Scene scene, Behavior behavior)
        {
            var behaviorList = GetBehaviorsForScene(scene);
            behaviorList.Add(behavior);
        }

        internal void RemoveBehavior(Scene scene, Behavior behavior)
        {
            var behaviorList = GetBehaviorsForScene(scene);
            behaviorList.Remove(behavior);
        }

        private List<Behavior> GetBehaviorsForScene(Scene scene)
        {
            return _behaviorsByScene.ContainsKey(scene)
                ? _behaviorsByScene[scene]
                : (_behaviorsByScene[scene] = new List<Behavior>());
        }

        public override void Update(GameTime gameTime)
        {
            var scene = _engine.SceneManager.ActiveScene;
            if (scene == null) return;

            var behaviors = GetBehaviorsForScene(scene);
            foreach (var behavior in behaviors.ToArray())
            {
                behavior.Update(gameTime);
            }

            foreach (var behavior in behaviors.ToArray())
            {
                behavior.UpdateCoroutines(gameTime);
            }
        }
    }
}
