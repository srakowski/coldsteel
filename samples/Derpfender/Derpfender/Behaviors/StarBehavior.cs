using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Behaviors
{
    class StarBehavior : Behavior
    {
        private float _speed;

        public StarBehavior(float alpha)
        {
            _speed = alpha / 5000F;
        }

        public override void Update()
        {
            this.Transform.Position += new Vector2(-1, 0) * _speed * Delta;
            if (this.Transform.Position.X < 0)
                this.Transform.Position += new Vector2(800, 0);
        }
    }
}
