﻿using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections;

namespace Derpfender.Behaviors
{
    class ShipBehavior : Behavior
    {
        private float _speed = .4f;

        private bool _allowFire = true;

        private Random _rand = new Random();

        private int _fireRate = 100;

        public override void Update()
        {
            if (Input.GetButtonControl("MoveUp").IsDown())
                this.Transform.Position += new Vector2(0, -1) * _speed * GameTime.Delta;

            if (Input.GetButtonControl("MoveDown").IsDown())
                this.Transform.Position += new Vector2(0, 1) * _speed * GameTime.Delta;

            if (Input.GetButtonControl("Fire").IsDown() && _allowFire)
                StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            _allowFire = false;
            AudioSource.Play();
            World.AddGameObject("bullet")
                .Set.Position(this.Transform.Position + new Vector2(24, 0))
                .Add.SpriteRenderer("flash", Color.WhiteSmoke)
                .Add.Component(new BulletBehavior(new Vector2(1, _rand.Next(-60, 61) / 1000f)))
                .Add.BoxCollider(10, 10);

            //    .AddComponent(new ParticleSystem(GetLayer("particles"), GetContent<Texture2D>("smoke")) { MaxScaleVelocity = 0.01f })
            //    .AddComponent(new ParticleSystem(GetLayer("particles"), GetContent<Texture2D>("smoke")) { Color = Color.Red, TTL = 30f })
            //    .AddComponent(new ParticleSystem(GetLayer("particles"), GetContent<Texture2D>("smoke")) { Color = Color.Yellow, TTL = 40f })

            yield return WaitMSecs(_fireRate);
            _allowFire = true;
        }
    }
}
