using Microsoft.Xna.Framework.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core
{
    internal class ContentManager
    {
        private Dictionary<string, object> _gameContent = new Dictionary<string, object>();

        private Microsoft.Xna.Framework.Content.ContentManager _gameContentManager;

        private Dictionary<string, object> _sceneContent = new Dictionary<string, object>();

        private Microsoft.Xna.Framework.Content.ContentManager _sceneContentManager;

        internal ContentManager(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
            _gameContentManager = contentManager;
            _sceneContentManager = new Microsoft.Xna.Framework.Content.ContentManager(
                _gameContentManager.ServiceProvider,
                _gameContentManager.RootDirectory);
        }

        public T Load<T>(string assetName, Scope scope = Scope.Game)
        {
            if (_gameContent.ContainsKey(assetName))
                return (T)_gameContent[assetName];
            if (_sceneContent.ContainsKey(assetName))
                return (T)_sceneContent[assetName];

            var content = _gameContentManager.Load<T>(assetName);
            if (scope == Scope.Game)
                _gameContent[assetName] = content;
            else
                _sceneContent[assetName] = content;
            return content; 
        }

        public T LoadSceneContent<T>(string assetName) =>
            Load<T>(assetName, Scope.Scene);

        public T LoadGameContent<T>(string assetName) =>
            Load<T>(assetName, Scope.Game);

        internal void UnloadGameContent()
        {
            _gameContent.Clear();
            _gameContentManager.Unload();
        }

        internal void UnloadSceneContent()
        {
            _sceneContent.Clear();
            _sceneContentManager.Unload();
        }

        internal void Unload()
        {
            _gameContent.Clear();
            _gameContentManager.Unload();
        }
    }
}
