using Coldsteel.Rendering;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Coldsteel.Physics;

namespace Derpfender.Behaviors
{
    class BulletBehavior : Behavior
    {
        //private float _speed = 2f;

        private bool _swappedTexture = false;

        private Texture2D _bulletTexture;

        public override void Activate()
        {
            _bulletTexture = Content.Load<Texture2D>("Sprites/bullet");
        }

        public override void OnCollision(Collision collision)
        {
            var with = collision.Entity1 == this.Entity
                ? collision.Entity2
                : collision.Entity1;

            if (!with.Tags.Contains("enemy"))
                return;

            Destroy(Entity);
        }

        public override void Update()
        {
            // TODO: emit
            //ParticleEmitter?.Emit(100);

            if (!_swappedTexture)
            {
                var spriteRenderer = this.Entity.Components.OfType<SpriteRenderer>().First();
                spriteRenderer.Texture2D = _bulletTexture;
                _swappedTexture = true;
            }

            if (this.Transform.Position.X > 1280)
                Destroy(this.Entity);
        }
    }
}
