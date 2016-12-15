// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Composition;
using Coldsteel.Fluent;

namespace Coldsteel.Examples.ArcadePhysics
{
    [StartupScene]
    public class AsteroidsMovement : ReflectiveSceneBuilder
    {
        public GameObject World { get; } = new GameObject()
            .Add(new Coldsteel.Physics.Arcade.World());

    }
}
