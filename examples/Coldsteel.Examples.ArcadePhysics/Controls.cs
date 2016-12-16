// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using Coldsteel.Composition;
using Coldsteel.Input;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Examples.ArcadePhysics
{
    public class Controls : IControlsBuilder
    {
        private List<IControl> _controls = new List<IControl>();

        public void ConfigureControls()
        {
            _controls.Add(new KeyboardButtonControlBinding(Keys.Up));
            _controls.Add(new KeyboardButtonControlBinding(Keys.Down));
            _controls.Add(new KeyboardButtonControlBinding(Keys.Left));
            _controls.Add(new KeyboardButtonControlBinding(Keys.Right));
        }

        public IEnumerable<IControl> GetResult() => _controls;
    }
}
