using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Configuration;
using System.Reflection;
using Microsoft.Xna.Framework.Content;
using Coldsteel.Core;
using System.Linq;
using System.Diagnostics;

namespace Coldsteel.Composition
{
    public class GameComposer
    {
        public string StartingSceneId { get; set; }

        public ISceneDirector SceneDirector { get; set; }

        public void Compose(ContentManager content)
        {
            try
            {
                var gameConfig = content.Load<Configuration.Game>("game");

                Assembly.LoadFrom("Behaviors.dll");

                var sceneCatalog = new List<Configuration.Scene>();
                foreach (var sceneConfig in gameConfig.Scenes)
                {
                    var scene = content.Load<Configuration.Scene>(sceneConfig);
                    sceneCatalog.Add(scene);
                    if (scene.IsStarting)
                        StartingSceneId = scene.Id;
                }
                StartingSceneId = StartingSceneId ?? sceneCatalog.First().Id;

                SceneDirector = new SceneDirector(sceneCatalog, gameConfig.Content);
            }
            catch { }
        }
    }
}
