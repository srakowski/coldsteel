using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockBehavior : Behavior
    {
        public bool CollisionWasTriggered { get; internal set; }
        public object GameObjectCollidedWith { get; internal set; }

        public override void OnCollision(Collision collision)
        {
            this.CollisionWasTriggered = true;
            this.GameObjectCollidedWith = collision.GameObject;
        }

        internal T MockGetContent<T>(string path) where T : class
        {
            return GetContent<T>(path);
        }

        internal Layer MockGetDefaultLayer()
        {
            return DefaultLayer;
        }

        internal void MockDestroy()
        {
            this.Destroy();
        }
    }
}
