// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel.Physics
{
    internal class PhysicsManager : GameComponent, IPhysicsManager
    {
        private ISceneManager _sceneManager;

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
            var worlds = e.Scene.Elements.OfType<World>();
            if (!worlds.Any(w => w.Name == Body.DefaultWorldName))
                e.Scene.AddElement(new World(Body.DefaultWorldName));
        }

        public override void Update(GameTime gameTime)
        {
            if (_sceneManager?.ActiveScene == null)
                return;

            var worlds = _sceneManager.ActiveScene.Elements.OfType<World>();
            var bodies = _sceneManager.ActiveScene.GameObjects.SelectMany(go => go.Components.OfType<Body>());
            foreach (var world in worlds)
            {
                var bodiesThisWorld = bodies.Where(b => b.World == world.Name);
                world.Step(gameTime, bodiesThisWorld);
            }
        }
    }
}
