using System;
using Coldsteel.Core;
using Microsoft.Xna.Framework.Content;

namespace Coldsteel.Core
{
    internal class SceneBuilder : ISceneBuilder
    {
        private Scene _scene = null;

        private Scene _completedScene;

        private ContentManager _content;

        public bool HasResult => _completedScene != null;

        public SceneBuilder(ContentManager content)
        {
            _content = content;
        }

        public void Begin(string name)
        {
            this._scene = new Scene()
            {
                Name = name
            };
        }

        public object AddContent(Type type, string assetName)
        {
            var content = _content.Load(type, assetName);
            _scene.Content.Set(assetName, content);
            return content;
        }

        public void AddControl()
        {
        }

        public void AddLayer()
        {
        }

        public void AddGameObject(GameObject gameObject)
        {
            _scene.GameObjects.Add(gameObject);
        }

        public void End()
        {
            _completedScene = _scene;
            _scene = null;
        }

        public Scene GetResult()
        {
            var scene = _completedScene;
            _completedScene = null;
            return scene;
        }
    }
}
