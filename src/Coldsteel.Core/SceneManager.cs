using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Coldsteel.Core
{
    public class SceneManager
    {
        public ISceneCatalog SceneCatalog { get; set; }

        private Scene _activeScene;

        private Scene _pendingScene;

        private ContentManager _content;

        private ControlsManager _controls;

        private bool _initialized;

        private Game _game;

        internal event EventHandler<EventArgs> ActiveSceneChanged;

        internal Scene ActiveScene => _activeScene;

        public SceneManager(Game game)
        {
            _game = game;
            _content = new ContentManager(game.Content);
            _controls = new ControlsManager();
            _initialized = false;
        }

        public void Start()
        {

        }

        internal void Start(string sceneId)
        {
            UnloadActiveScene();
            _pendingScene = SceneCatalog.Instantiate(sceneId);
            if (_initialized)
                LoadPendingScene();
        }

        public void Initialize()
        {
            _initialized = true;
            if (_pendingScene != null)
                LoadPendingScene();
        }

        private void LoadPendingScene()
        {
            var pendingScene = _pendingScene;
            _pendingScene = null;

            pendingScene.SceneManager = this;
            pendingScene.Content = _content;
            pendingScene.Controls = _controls;
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
