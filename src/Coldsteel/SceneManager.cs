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
        private ISceneComposer _sceneComposer;

        private Scene _outgoingScene;

        private string _pendingScene;

        private bool _initialized;

        /// <summary>
        /// Is triggered when the ActiveScene is updated.
        /// </summary>
        public event EventHandler<EventArgs> ActiveSceneChanged;

        /// <summary>
        /// The scene being played.
        /// </summary>
        public Scene ActiveScene { get; private set; }

        public SceneManager(Game game) : base(game)
        {
            game.Services.AddService<ISceneManager>(this);
            _initialized = false;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._sceneComposer = Game.Services.GetService<ISceneComposer>();
            _initialized = true;

            if (_pendingScene != null)
            {
                var sceneName = _pendingScene;
                _pendingScene = null;
                Start(sceneName);
            }
        }

        public void Start(string sceneName)
        {
            if (!_initialized)
            {
                _pendingScene = sceneName;
                return;
            }

            if (_sceneComposer == null)
            {
                _sceneComposer = Game.Services.GetService<ISceneComposer>();
                if (_sceneComposer == null)
                    throw new Exception("an ISceneComposer service provider is required");
            }

            _outgoingScene = ActiveScene;
            var scene = _sceneComposer.ComposeScene(sceneName);
            scene.Activate(new ContentManager(Game.Content.ServiceProvider, Game.Content.RootDirectory));
            ActiveScene = scene;
            ActiveSceneChanged?.Invoke(this, null);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _outgoingScene?.Deactivate();
            _outgoingScene = null;
            ActiveScene?.Update(gameTime);
        }
    }
}
