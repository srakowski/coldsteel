using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Collider : GameObjectComponent
    {
        public bool Enabled { get; set; } = true;

        internal abstract Rectangle Bounds { get; }

        internal void NotifyCollision(Collider collider)
        {
            this.GameObject?.NotifyCollision(new Collision(collider.GameObject));
        }
    }
}
