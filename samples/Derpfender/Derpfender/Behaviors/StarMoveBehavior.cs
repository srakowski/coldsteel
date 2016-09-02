using Coldsteel;
using Microsoft.Xna.Framework;

namespace Derpfender.Behaviors
{
    class StarMoveBehavior : Behavior
    {
        private float _speed;

        public StarMoveBehavior(int alpha)
        {
            _speed = alpha / 5000F;
        }

        public override void Update()
        {
            this.Transform.Position += new Vector2(-1, 0) * _speed * GameTime.Delta;
            if (this.Transform.Position.X < 0)
                this.Transform.Position += new Vector2(1280, 0);
        }
    }
}
