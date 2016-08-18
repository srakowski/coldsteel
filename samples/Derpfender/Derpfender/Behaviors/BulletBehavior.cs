using Coldsteel;
using Microsoft.Xna.Framework;
using System.Linq;
using Coldsteel.Rendering;

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

        public override void OnCollision(GameObject with)
        {
            if (!with.Tags.Contains("enemy"))
                return;

            Kill();
        }

        public override void Update()
        {
            if (!_swappedTexture)
            {
                Renderer.As<SpriteRenderer>().Image = Content.Images["bullet"];
                _swappedTexture = true;
            }

            this.Transform.Position += (_direction * _speed * GameTime.Delta);
            if (this.Transform.Position.X > 1280)
                Kill();
        }
    }
}
