using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Collider : GameObjectComponent
    {
        public bool Enabled { get; set; } = true;

        public bool IsDynamic { get; set; } = false;

        internal abstract Rectangle Bounds { get; }       

        internal bool NotifyCollision(Collider collider)
        {
            var collision = new Collision(collider.GameObject);
            this.GameObject?.NotifyCollision(collision);
            return collision.Handled;
        }

        public Collider SetIsDynamic(bool isDynamic)
        {
            this.IsDynamic = isDynamic;
            return this;
        }
    }
}
