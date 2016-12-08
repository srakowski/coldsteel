using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
            if (Input.GetButtonControl("Up").IsDown())
                this.Transform.Position += new Vector2(0, -1) * _speed * Delta;

            if (Input.GetButtonControl("Down").IsDown())
                this.Transform.Position += new Vector2(0, 1) * _speed * Delta;

            if (Input.GetButtonControl("Select").IsDown() && _allowFire)
                StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            _allowFire = false;
            //AudioSource.Play();
            //TODO: how to add stuff to the scene?
            //World.AddGameObject("bullet")
            //    .Set.Position(this.Transform.Position + new Vector2(24, 0))
            //    .Add.SpriteRenderer("flash", Color.WhiteSmoke)
            //    .Add.Component(new BulletBehavior(new Vector2(1, _rand.Next(-60, 61) / 1000f)))
            //    .Add.BoxCollider(10, 10);

            yield return WaitYieldInstruction.Create(_fireRate);
            _allowFire = true;
        }
    }
}
