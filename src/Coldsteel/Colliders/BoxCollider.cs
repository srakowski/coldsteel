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
                var t = this.GameObject.Transform;
                var pos = t.Position + _offset;
                return new Rectangle((int)(pos.X - (_width / 2)), (int)(pos.Y - (_height / 2)),
                    (int)_width, (int)_height);
            }
        }

        private int _width = 0;

        private int _height = 0;

        private Vector2 _offset = Vector2.Zero;

        public BoxCollider(int width, int height)
            : this(width, height, Vector2.Zero)
        {
        }

        public BoxCollider(int width, int height, Vector2 offset)
        {
            this._width = width;
            this._height = height;
            this._offset = offset;
        }
    }
}
