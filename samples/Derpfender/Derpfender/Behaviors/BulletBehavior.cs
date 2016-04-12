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
    class BulletBehavior : Behavior
    {
        private Vector2 _direction;

        private float _speed = 2f;

        private bool _swappedTexture = false;

        public BulletBehavior(Vector2 direction)
        {
            direction.Normalize();
            _direction = direction;
        }

        public override void OnCollision(Collision collision)
        {
            if (collision.GameObject.Tag != "enemy")
                return;

            Destroy();
        }

        public override void Update(IGameTime gameTime)
        {
            if (!_swappedTexture)
            {
                GetComponent<SpriteRenderer>().Texture = GetContent<Texture2D>("bullet");
                _swappedTexture = true;
            }            

            this.Transform.Position += (_direction * _speed * gameTime.Delta);
            if (this.Transform.Position.X > 1280)
                Destroy();
        }
    }
}
