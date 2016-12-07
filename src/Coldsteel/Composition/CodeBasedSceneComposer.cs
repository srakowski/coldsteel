// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Composition
{
    /// <summary>
    /// This scene composer is used when the developer has opted to manually
    /// compose a Scene in code. Looks for classes that implement ISceneBuilder
    /// </summary>
    public class CodeBasedSceneComposer : ISceneComposer
    {
        private List<Type> _sceneBuilderTypes;

        public CodeBasedSceneComposer()
        {
            var sceneBuilderType = typeof(ISceneBuilder);
            _sceneBuilderTypes = new List<Type>(AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => sceneBuilderType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract));
        }

        public Scene ComposeScene(string sceneName)
        {
            var sceneBuilderType = FindSceneBuilderType(sceneName);
            var scene = BuildScene(sceneBuilderType);
            return scene;
        }

        private static Scene BuildScene(Type sceneBuilderType)
        {
            var sceneBuilder = Activator.CreateInstance(sceneBuilderType) as ISceneBuilder;
            sceneBuilder.ConfigureLayers();
            sceneBuilder.ConfigureGameObjects();
            var scene = sceneBuilder.GetResult();
            return scene;
        }

        private Type FindSceneBuilderType(string sceneName)
        {
            var sceneBuilderType = _sceneBuilderTypes.FirstOrDefault(t => t.Name == sceneName);
            if (sceneBuilderType == null)
                throw new Exception($"scene {sceneName} does not exist");
            return sceneBuilderType;
        }
    }
}
