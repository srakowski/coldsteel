using Coldsteel;
using Coldsteel.Audio;
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
            this.GameObject.Components.OfType<AudioSource>().First().Play();

            Scene.AddElement(new GameObject()
                .SetPosition(this.Transform.Position)
                .Add(new SpriteRenderer("Sprites/flash")
                {
                    Color = Color.WhiteSmoke
                })
                .Add(new BulletBehavior(new Vector2(1, _rand.Next(-60, 61) / 1000f))));

            yield return WaitYieldInstruction.Create(_fireRate);
             _allowFire = true;
        }
    }
}
