using FarseerPhysics;
using System;

namespace Coldsteel.Physics
{
    public class BoxCollider : Collider
    {
        private int _width;
        private int _height;

        public BoxCollider(int width, int height)
            : base()
        {
            _width = width;
            _height = height;
        }

        public override void Initialize()
        {
            this.Transform.Body.CreateBoxCollider(_width, _height);
        }
    }
}
