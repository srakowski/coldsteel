// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel.Composition
{
    /// <summary>
    /// Contract that defines the steps for building a scene.
    /// </summary>
    public interface ISceneBuilder
    {
        void ConfigureScene();
        Scene GetResult();
    }
}
