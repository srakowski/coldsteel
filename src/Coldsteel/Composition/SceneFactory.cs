// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Composition
{
    internal class SceneFactory : ISceneFactory
    {
        private IEnumerable<Type> _sceneBuilderTypes;

        public SceneFactory(IEnumerable<Type> sceneBuilderTypess)
        {
            _sceneBuilderTypes = sceneBuilderTypess;
        }

        public Scene Create(string name)
        {
            var sceneBuilderType = FindSceneBuilderType(name);
            var scene = BuildScene(sceneBuilderType);
            return scene;
        }

        private static Scene BuildScene(Type sceneBuilderType)
        {
            var sceneBuilder = Activator.CreateInstance(sceneBuilderType) as ISceneBuilder;
            sceneBuilder.ConfigureScene();
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
