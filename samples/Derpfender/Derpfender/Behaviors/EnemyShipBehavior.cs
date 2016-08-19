//using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Coldsteel;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Rendering;

namespace Derpfender.Behaviors
{
    class EnemyShipBehavior : Behavior
    {
        private Vector2 _direction;

        private float _speed = 0f;

        //		private GameObject _camera;

        private Random _rand = new Random();

        public EnemyShipBehavior(float speed)
        {
            //			_camera = camera;
            _direction = new Vector2(-1, 0);
            _speed = speed;
        }

        public override void Update()
        {
            this.Transform.Position += (_direction * _speed * GameTime.Delta);
            if (this.Transform.Position.X < -24)
                Kill();
        }


        public override void OnCollision(GameObject with)
        {
            var withGameObject = (with as GameObject);
            if (!withGameObject.Tags.Contains("bullet"))
                return;

            //GetComponent<Collider>().Enabled = false;
            //var audio = GetComponent<AudioSource>();
            //audio.Play(1, _rand.Next(-20, 21) / 100f, 0);
            //_camera.GetComponent<ShakeBehavior>().Shake();
            StartCoroutine(BeginRemove());
        }

        private IEnumerator BeginRemove()
        {
            var renderer = Renderer.As<SpriteRenderer>();
            renderer.Image = Content.Images["debris"];
            Collider.Enabled = false;
            //renderer.Layer = GetLayer("background");
            for (byte a = 200; a > 30; a--)
            {
                renderer.Alpha = a;
                yield return null;
            }
            Kill();
        }
    }
}
