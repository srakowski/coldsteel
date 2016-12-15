// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Composition;
using Coldsteel.Physics;

namespace Coldsteel.Examples.ArcadePhysics
{
    [StartupScene]
    public class AsteroidsMovement : ReflectiveSceneBuilder
    {
        public World World { get; } = new Physics.Arcade.World();

        public GameObject Ship { get; } = new GameObject()
            .AddComponent(new Physics.Arcade.Body()
            {
                Drag = 100,
                MaxVelocity = 200
            });
    }
}
