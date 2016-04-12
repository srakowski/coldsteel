using Coldsteel;
using Coldsteel.Colliders;
using Coldsteel.Controls;
using Coldsteel.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        private int _fireRate = 60;

        public override void HandleInput(IGameTime gameTime, Input input)
        {
            if (input.GetControl<ButtonControl>("MoveUp").IsDown() ||
                input.GetControl<ButtonControl>("AltMoveUp").IsDown())
            {
                this.Transform.Position += new Vector2(0, -1) * _speed * gameTime.Delta;
            }

            if (input.GetControl<ButtonControl>("MoveDown").IsDown() ||
                input.GetControl<ButtonControl>("AltMoveDown").IsDown())
            {
                this.Transform.Position += new Vector2(0, 1) * _speed * gameTime.Delta;
            }

            if ((input.GetControl<ButtonControl>("Fire").IsDown() || 
                input.GetControl<ButtonControl>("AltFire").IsDown())
                && _allowFire)
                StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            _allowFire = false;
            var fireSound = GetComponent<AudioSource>();
            fireSound.Play(1f, _rand.Next(-10, 11) / 100f, 0);
            AddGameObject(new GameObject()
                .SetPosition(this.Transform.Position + new Vector2(24, 0))
                .AddComponent(new SpriteRenderer(DefaultLayer, GetContent<Texture2D>("flash")))
                .AddComponent(new BulletBehavior(new Vector2(1, _rand.Next(-60, 61) / 1000f)))
                .AddComponent(new BoxCollider(10, 10)));
            yield return WaitMSecs(_fireRate);
            _allowFire = true;
        }
    }
}
