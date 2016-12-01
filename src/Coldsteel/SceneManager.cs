using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Coldsteel
{
    public class SceneManager
    {
        private Scene _activeScene;

        private Scene _pendingScene;

        private ContentBundle _content;

        private bool _initialized;

        private Game _game;

        private RenderingManager _renderingManager;

        private ScriptingManager _scriptingManager;

        internal SceneManager(Game game)
        {
            _game = game;
            _content = new ContentBundle(game.Content);
            _initialized = false;
            _scriptingManager = new ScriptingManager(game);
            _renderingManager = new RenderingManager(game);
        }

        public void Start<T>() where T : Scene, new()
        {
            UnloadActiveScene();
            _pendingScene = Activator.CreateInstance<T>();
            if (_initialized)
                LoadPendingScene();
        }

        internal void Initialize()
        {
            _scriptingManager.Initialize();
            _renderingManager.Initialize();
            _initialized = true;
            if (_pendingScene != null)
                LoadPendingScene();
        }

        internal void Update(GameTime gameTime) =>
            _scriptingManager.Update(gameTime, _activeScene);

        internal void Render(GameTime gameTime) =>
            _renderingManager.Render(_activeScene);

        private void LoadPendingScene()
        {
            var pendingScene = _pendingScene;
            _pendingScene = null;

            pendingScene.SceneManager = this;
            pendingScene.Content = _content;
            pendingScene.Configure();
            pendingScene.Initialize();
            _activeScene = pendingScene;
        }

        private void UnloadActiveScene()
        {
            _content.Unload();
            _activeScene = null;
        }
    }
}
