// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Coldsteel.Composition
{
    internal class CodeBasedGameComposer : IGameComposer
    {
        private IEnumerable<Type> _controlsBuilderTypes;

        public CodeBasedGameComposer()
        {
            _controlsBuilderTypes = TypeHelper.FindConcreteClassesAssignableToType<IControlsBuilder>();
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
    }
}
