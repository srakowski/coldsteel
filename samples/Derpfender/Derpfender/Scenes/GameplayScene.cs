﻿using Coldsteel.Composition;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Fluent;
using Coldsteel.Components;
using Derpfender.Behaviors;

namespace Derpfender.Scenes
{
    public class GameplayScene : SpaceSceneBase
    {
        public override Color BackgroundColor { get; } = Color.Black;

        public Layer Debris { get; } = new Layer("debris", -1)
            .SetBlendState(BlendState.NonPremultiplied);

        public GameObject Ship { get; } = new GameObject()
            .SetName("ship") // TODO: constructor should accept name
            .SetPosition(60, 360)
            .SetRotationInDegrees(90)
            .Add(new SpriteRenderer("sprites/ship"))
            //.Add(new AudioSource("audio/fire")) TODO: implement
            .Add(new ShipBehavior());


    }
}