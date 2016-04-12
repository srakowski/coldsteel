using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Coldsteel.Renderers;
using Microsoft.Xna.Framework.Graphics;

namespace Derpfender.Behaviors
{
    class EnemyShipBehavior : Behavior
    {        
        private Vector2 _direction;

        private float _speed = 0f;

        private GameObject _camera;

        private Random _rand = new Random();

        public EnemyShipBehavior(GameObject camera, Vector2 direction, float speed)
        {
            _camera = camera;
            direction.Normalize();
            _direction = direction;
            _speed = speed;
        }

        public override void OnCollision(Collision collision)
        {
            if (collision.GameObject.Tag != "bullet")
                return;

            GetComponent<Collider>().Enabled = false;
            var audio = GetComponent<AudioSource>();
            audio.Play(1, _rand.Next(-20, 21) / 100f, 0);
            _camera.GetComponent<ShakeBehavior>().Shake();            
            StartCoroutine(BeginRemove());
        }

        private IEnumerator BeginRemove()
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.Texture = GetContent<Texture2D>("debris");
            renderer.Layer = GetLayer("background");
            for (byte a = 200; a > 30; a--)
            {
                renderer.Alpha = a;
                yield return null;
            }
            Destroy();
        }

        public override void Update(IGameTime gameTime)
        {
            this.Transform.Position += (_direction * _speed * gameTime.Delta);
            if (this.Transform.Position.X < -24)
                Destroy();
        }
    }
}
