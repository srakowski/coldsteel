// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Physics
{
    internal class PhysicsManager : GameComponent, IPhysicsManager
    {
        private ISceneManager _sceneManager;

        private List<World> _worlds = new List<World>();

        public PhysicsManager(Game game) : base(game)
        {
            game.Services.AddService<IPhysicsManager>(this);
        }

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager = Game.Services.GetService<ISceneManager>();
            _sceneManager.SceneActivated += _sceneManager_SceneActivated;
        }

        private void _sceneManager_SceneActivated(object sender, SceneActivatedEventArgs e)
        {
            var scene = e.Scene;
            var worlds = scene.Elements.OfType<World>();
            if (!worlds.Any(w => w.Name == PhysicsComponent.DefaultWorldName))
            {
                e.Scene.AddElement(new World(PhysicsComponent.DefaultWorldName));
            }
            _worlds.Clear();
            _worlds.AddRange(scene.Elements.OfType<World>());
            scene.SceneElementAdded += Scene_SceneElementAdded;
            scene.SceneElementRemoved += Scene_SceneElementRemoved;
        }

        public override void Update(GameTime gameTime)
        {
            if (_sceneManager?.ActiveScene == null)
                return;

            var gameObjects = _sceneManager.ActiveScene.Elements.OfType<GameObject>();
            var pcs = gameObjects.SelectMany(go => go.Components.OfType<PhysicsComponent>());
            foreach (var world in _worlds)
            {
                var physicsComponentsThisWorld = pcs.Where(b => b.World == world.Name);
                world.Step(gameTime, physicsComponentsThisWorld);
            }
        }

        private void Scene_SceneElementAdded(object sender, SceneElementEventArgs e)
        {
            if (e.SceneElement is World)
                _worlds.Add(e.SceneElement as World);
        }

        private void Scene_SceneElementRemoved(object sender, SceneElementEventArgs e)
        {
            if (e.SceneElement is World)
                _worlds.Remove(e.SceneElement as World);
        }
    }
}
