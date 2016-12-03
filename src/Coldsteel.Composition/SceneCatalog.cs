using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Configuration;
using Coldsteel.Core;
using System.Linq;

namespace Coldsteel.Composition
{
    internal class SceneCatalog : ISceneCatalog
    {
        private List<Configuration.Scene> _scenes = new List<Configuration.Scene>();

        public string StartingSceneId { get; internal set; }

        public Core.Scene Instantiate(string sceneId)
        {
            var scene = _scenes.First(s => s.Id == sceneId);
            var newScene = new Core.Scene();
            return newScene;
        }

        internal void Add(Configuration.Scene scene)
        {
            _scenes.Add(scene);
        }
    }
}
