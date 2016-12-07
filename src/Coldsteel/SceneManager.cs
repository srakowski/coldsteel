// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;

namespace Coldsteel
{
    /// <summary>
    /// Is responsible for activating and transitioning from scene to scene.
    /// </summary>
    internal class SceneManager : GameComponent, ISceneManager
    {
        private ISceneComposer _sceneComposer;

        private string _pendingScene;

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
        }

        public override void Initialize()
        {
            base.Initialize();
            this._sceneComposer = Game.Services.GetService<ISceneComposer>();
            if (this._sceneComposer == null)
                throw new Exception("an ISceneComposer service provider is required");

            if (_pendingScene != null)
            {
                var sceneName = _pendingScene;
                _pendingScene = null;
                Start(sceneName);
            }
        }

        public void Start(string sceneName)
        {
            if (_sceneComposer == null)
            {
                _pendingScene = sceneName;
                return;
            }

            var scene = _sceneComposer.ComposeScene(sceneName);
            scene.Activate();
            ActiveScene = scene;
            ActiveSceneChanged?.Invoke(this, null);
        }
    }
}
