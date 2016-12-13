// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;

namespace Coldsteel.Composition
{
    /// <summary>
    /// Contract that defines the steps for configuring the game controls.
    /// </summary>
    public interface IControlsBuilder
    {
        void ConfigureControls();
        IEnumerable<IControl> GetResult();
    }
}
