using Coldsteel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Behaviors
{
    class SpawnEnemyBehavior : Behavior
    {
        private bool _allowSpawn = true;

        private Random _rand = new Random();

        private int _spawnWait = 10;

        public override void Update()
        {
            if (_allowSpawn)
                StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            _allowSpawn = false;
            World.AddGameObject("enemy")
                .Set.Position(1300, _rand.Next(20, 700))
                .Set.RotationDegrees(270)
                .Add.SpriteRenderer("enemy")
                .Add.BoxCollider(24, 24)
                .Add.AudioSource("explode")
                .Add.RigidBody()
                .Add.Component(new EnemyShipBehavior(_rand.Next(100, 200) / 1000f));
            yield return WaitMSecs(_spawnWait);
            _allowSpawn = true;
        }
    }
}
