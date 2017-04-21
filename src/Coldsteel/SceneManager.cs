// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace Coldsteel
{
    /// <summary>
    /// Is responsible for activating and transitioning from scene to scene.
    /// </summary>
    internal class SceneManager : GameComponent, ISceneManager
    {
        private Func<Scene> _pendingScene;

        /// <summary>
        /// Is triggered when the ActiveScene is updated.
        /// </summary>
        public event EventHandler<SceneActivatedEventArgs> SceneActivated;

        /// <summary>
        /// The scene being played.
        /// </summary>
        public Scene ActiveScene { get; private set; }

        public SceneManager(Game game, Func<Scene> openingScene) : base(game)
        {
            _pendingScene = openingScene;
            game.Services.AddService<ISceneManager>(this);
        }

        public void Start(Func<Scene> scene)
        {
            _pendingScene = scene;
        }

        public override void Update(GameTime gameTime)
        {
            LoadPendingScene();
            ActiveScene?.Update(gameTime);
        }

        private void LoadPendingScene()
        {
            if (_pendingScene == null)
                return;

            var newScene = _pendingScene();
            _pendingScene = null;

            ActiveScene?.Deactivate();

            var context = new Context(
                newScene,
                this,
                Game.Services.GetService<IPhysicsManager>(),
                Game.Services.GetService<IInputManager>(),
                new ContentManager(Game.Content.ServiceProvider, Game.Content.RootDirectory),
                Game.GraphicsDevice);

            newScene.Activate(context);
            ActiveScene = newScene;
            SceneActivated?.Invoke(this, new SceneActivatedEventArgs()
            {
                Scene = newScene
            });
        }
    }
}
