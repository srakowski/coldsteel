using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace Coldsteel
{
    public class SceneManager
    {
        private Scene _activeScene;

        private Scene _pendingScene;

        private ContentBundle _content;

        private bool _initialized;

        internal SceneManager(ContentManager contentManager)
        {
            _content = new ContentBundle(contentManager);
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
            _initialized = true;
            if (_pendingScene != null)
                LoadPendingScene();
        }

        internal void Update(GameTime gameTime) =>
            _activeScene.Update(gameTime);

        internal void Render(GameTime gameTime) =>
            _activeScene.Render(gameTime);

        private void LoadPendingScene()
        {
            var pendingScene = _pendingScene;
            _pendingScene = null;

            pendingScene.SceneManager = this;
            pendingScene.Content = _content;
            pendingScene.Configure();
            _activeScene = pendingScene;
            _content.Load();
        }

        private void UnloadActiveScene()
        {
            _content.Unload();
            _activeScene = null;
        }
    }
}
