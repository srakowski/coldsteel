using FarseerPhysics;
using System;

namespace Coldsteel.Physics
{
    public class BoxCollider : Collider
    {
        private int _width;
        private int _height;

        public BoxCollider(int width, int height)
        {
            _width = width;
            _height = height;
        }

        internal override void Initialize()
        {
            base.Initialize();
            Body.CreateBox(_width, _height);
        }
    }
}
