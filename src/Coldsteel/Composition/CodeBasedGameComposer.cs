// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using static Coldsteel.Helpers.TypeHelper;

namespace Coldsteel.Composition
{
    internal class CodeBasedGameComposer : IGameComposer
    {
        public const string GameCompositionMethodKey = "Code";

        private IEnumerable<Type> _controlsBuilderTypes;

        private IEnumerable<Type> _sceneBuilderTypes;

        public CodeBasedGameComposer()
        {
            _controlsBuilderTypes = FindConcreteClassesAssignableToType<IControlsBuilder>();
            _sceneBuilderTypes = FindConcreteClassesAssignableToType<ISceneBuilder>();
        }

        public void ConfigureInput(IInputManager inputManager)
        {
            foreach (var controlsBuilderType in _controlsBuilderTypes)
            {
                var controlsBuilder = Activator.CreateInstance(controlsBuilderType) as IControlsBuilder;
                controlsBuilder.ConfigureControls();
                var controls = controlsBuilder.GetResult();
                foreach (var control in controls)
                    inputManager.AddControl(control);
            }
        }

        public ISceneFactory CreateSceneFactory() =>
            new SceneFactory(_sceneBuilderTypes);
    }
}
