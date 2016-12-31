using Coldsteel;
using Coldsteel.Audio;
using Coldsteel.Extensions;
using Coldsteel.Fluent;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Linq;

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
            var body = GameObject.Components.OfType<Body>().First();

            if (Input.GetButtonControl("Up").IsDown())
                this.Transform.Position += new Vector2(0, -1) * _speed * Delta;

            if (Input.GetButtonControl("Down").IsDown())
                this.Transform.Position += new Vector2(0, 1) * _speed * Delta;

            body.AngularAcceleration = 0f;

            if (Input.GetButtonControl("Left").IsDown())
                body.AngularAcceleration -= 200f;

            if (Input.GetButtonControl("Right").IsDown())
                body.AngularAcceleration += 200f;

            if (Input.GetButtonControl("Select").IsDown() && _allowFire)
                StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            _allowFire = false;

            this.GameObject.Components.OfType<AudioSource>().First().Play();

            Scene.AddElement(new GameObject()
                .AddTag("bullet")
                .SetPosition(this.Transform.Position.ShiftX(20))
                .AddComponent(new SpriteRenderer("Sprites/flash")
                {
                    Color = Color.WhiteSmoke
                })
                .AddComponent(new Body()
                {
                    Velocity = new Vector2(1f, _rand.Next(-60, 61) / 1000f),
                })
                .AddComponent(new BoxCollider(18))
                .AddComponent(new BulletBehavior()));

            yield return WaitYieldInstruction.Create(_fireRate);

             _allowFire = true;
        }
    }
}
