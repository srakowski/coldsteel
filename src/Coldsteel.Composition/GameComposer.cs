using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Configuration;
using System.Reflection;
using Microsoft.Xna.Framework.Content;

namespace Coldsteel.Composition
{
    public class GameComposer
    {
        public GameComposer()
        {
        }

        public ISceneCatalog Compose(ContentManager content, Configuration.Game gameConfig)
        {
            foreach (var assembly in gameConfig.Assemblies)
                Assembly.LoadFrom(assembly);

            var sceneCatalog = new SceneCatalog();
            foreach (var scene in gameConfig.Scenes)
                sceneCatalog.Add(content.Load<Configuration.Scene>(scene));

            sceneCatalog.StartingSceneId = gameConfig.StartingSceneId;
            return sceneCatalog;
        }
    }
}
