using System;
using System.Collections.Generic;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    internal class PhysicalWorld
    {
        private FarseerPhysics.Dynamics.World _farseerWorld;

        public PhysicalWorld()
        {
            this._farseerWorld = new FarseerPhysics.Dynamics.World(Microsoft.Xna.Framework.Vector2.Zero);
        }

        public void Add(GameObject gameObject)
        {
            if (gameObject.Body != null)
                return;

            gameObject.Body = new Body(_farseerWorld, gameObject);
        }

        public void Remove(GameObject gameObject)
        {
            if (gameObject.Body == null)
                return;

            gameObject.Body.Destroy();
            gameObject.Body = null;
        }

        internal void Update(GameTime gameTime)
        {
            // http://weblogs.asp.net/bsimser/farseer-tutorial-for-the-absolute-beginners
            _farseerWorld.Step(Math.Min((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f, (1f / 30f)));
        }
    }
}
