using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Behaviors
{
    class StarMoveBehavior : Behavior
    {
        private float _speed;

        public StarMoveBehavior(int alpha)
        {
            _speed = alpha / 5000F;
        }

        public override void Update(IGameTime gameTime)
        {
            this.Transform.Position += new Vector2(-1, 0) * _speed * gameTime.Delta;
            if (this.Transform.Position.X < 0)
                this.Transform.Position += new Vector2(1280, 0);
        }
    }
}
