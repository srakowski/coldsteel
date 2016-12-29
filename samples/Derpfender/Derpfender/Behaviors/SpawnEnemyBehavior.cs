// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel;
using Coldsteel.Audio;
using Coldsteel.Fluent;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections;

namespace Derpfender.Behaviors
{
    class SpawnEnemyBehavior : Behavior
    {
        private bool _allowSpawn = true;

        private Random _rand = new Random();

        private int _spawnWait = 300;

        //private ShakeBehavior _cameraShaker;

        public SpawnEnemyBehavior()//ShakeBehavior cameraShaker)
        {
            //_cameraShaker = cameraShaker;
        }

        public override void Activate()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                var go = new GameObject()
                    .SetPosition(900, _rand.Next(20, 700))
                    .SetRotationInDegrees(270)
                    .AddComponent(new CircleCollider(24))
                    .AddComponent(new Body()
                    {
                        Bounce = Vector2.One / 2f,
                        Velocity = new Vector2(-0.2f, 0)
                    })
                    .AddComponent(new SpriteRenderer("Sprites/enemy"));

                Scene.AddElement(go);
                    //.AddComponent(new AudioSource("audio/explode"))
                    //.AddComponent(new CircleCollider(72))
                    //.AddComponent(new Body()
                    //{
                    //    
                    //}));

                yield return WaitYieldInstruction.Create(_spawnWait);
            }
        }
    }
}
