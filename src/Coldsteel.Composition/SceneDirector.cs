using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Configuration;
using Coldsteel.Core;
using System.Linq;
using System.Collections;

namespace Coldsteel.Composition
{
    internal class SceneDirector : ISceneDirector
    {
        private IEnumerable<Configuration.Scene> _sceneCatalog;

        private IEnumerator<string> _steps;

        private GameObjectBuilder _gameObjectBuilder;

        public SceneDirector(IEnumerable<Configuration.Scene> sceneCatalog)
        {
            _sceneCatalog = sceneCatalog;
            _gameObjectBuilder = new GameObjectBuilder();
        }

        public void BeginConstruction(string sceneId, ISceneBuilder sceneBuilder)
        {
            var scene = _sceneCatalog.First(s => s.Id == sceneId);
            _steps = Steps(scene, sceneBuilder);
        }

        public void Update()
        {
            if (!(_steps?.MoveNext() ?? false))
            {
                _steps = null;
                return;
            }
        }
        
        public IEnumerator<string> Steps(Configuration.Scene scene, ISceneBuilder sceneBuilder)
        {
            var objectDirectory = new Dictionary<string, object>();
            var compositionTasks = new List<Action<Dictionary<string, object>>>();

            sceneBuilder.Begin(scene.Name);

            if (scene.Content != null)
                foreach (var content in scene.Content)
                {
                    yield return $"loading {content.Name}";
                    var type = TypeHelper.FindType(content.Type);
                    var result = sceneBuilder.AddContent(type, content.Name);
                    objectDirectory.Add(content.Id, result);
                }

            if (scene.Controls != null)
                foreach (var control in scene.Controls)
                {
                    sceneBuilder.AddControl();
                }

            if (scene.Layers != null)
                foreach (var control in scene.Layers)
                {
                    sceneBuilder.AddLayer();
                }

            if (scene.GameObjects != null)
                foreach (var gameObject in scene.GameObjects)
                {
                    var director = new GameObjectDirector(gameObject, _gameObjectBuilder);
                    director.Construct(objectDirectory, compositionTasks);
                    var result = _gameObjectBuilder.GetResult();
                    sceneBuilder.AddGameObject(result);
                    objectDirectory.Add(gameObject.Id, result);
                }

            foreach (var compositionTask in compositionTasks)
                compositionTask.Invoke(objectDirectory);

            sceneBuilder.End();
        }
    }
}
