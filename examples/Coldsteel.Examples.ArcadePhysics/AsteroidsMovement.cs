// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Composition;
using Coldsteel.Fluent;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;

namespace Coldsteel.Examples.ArcadePhysics
{
    [StartupScene]
    public class AsteroidsMovement : ReflectiveSceneBuilder
    {
        public override Color BackgroundColor => Color.Black;

        public World World { get; } = new Physics.Arcade.World();

        public GameObject Ship { get; } = new GameObject()
            .SetPosition(300, 300)
            .AddComponent(new SpriteRenderer("ship"))
            .AddComponent(new Physics.Arcade.Body()
            {
                Drag = 100,
                MaxVelocity = 200
            });
    }
}
