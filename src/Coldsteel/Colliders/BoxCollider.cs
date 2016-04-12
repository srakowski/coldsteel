using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Colliders
{
    public class BoxCollider : Collider
    {
        internal override Rectangle Bounds
        {
            get
            {
                var t = this.GameObject.GetComponent<Transform>();
                var pos = t.Position;
                return new Rectangle((int)(pos.X - (_width / 2)), (int)(pos.Y - (_height / 2)),
                    (int)_width, (int)_height);
            }
        }

        private int _width = 0;

        private int _height = 0;

        public BoxCollider(int width, int height)
        {
            this._width = width;
            this._height = height;
        }
    }
}
