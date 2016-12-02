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

        private ContentManager _content;

        private ControlsManager _controls;

        private bool _initialized;

        private Game _game;

        private InputManager _inputManager;

        private RenderingManager _renderingManager;

        private ScriptingManager _scriptingManager;

        internal event EventHandler<EventArgs> ActiveSceneChanged;

        internal Scene ActiveScene => _activeScene;

        internal SceneManager(Game game)
        {
            _game = game;
            _content = new ContentManager(game.Content);
            _inputManager = new InputManager(game);
            _controls = new ControlsManager(_inputManager);
            _scriptingManager = new ScriptingManager(game);
            _renderingManager = new RenderingManager(game);
            _initialized = false;
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
            _inputManager.Initialize();
            _scriptingManager.Initialize();
            _renderingManager.Initialize();
            _initialized = true;
            if (_pendingScene != null)
                LoadPendingScene();
        }

        internal void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);
            _scriptingManager.Update(gameTime, _activeScene);
        }

        internal void Render(GameTime gameTime) =>
            _renderingManager.Render(_activeScene);

        private void LoadPendingScene()
        {
            var pendingScene = _pendingScene;
            _pendingScene = null;

            pendingScene.SceneManager = this;
            pendingScene.Content = _content;
            pendingScene.Controls = _controls;
            pendingScene.Configure();
            pendingScene.Initialize();
            _activeScene = pendingScene;
            ActiveSceneChanged?.Invoke(this, null);
        }

        private void UnloadActiveScene()
        {
            _content.UnloadSceneContent();
            _controls.UnloadSceneControls();
            _activeScene = null;
        }
    }
}
