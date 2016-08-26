﻿using System;
using System.Collections.Generic;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    internal class PhysicalWorld
    {
        public Vector2 Gravity
        {
            get { return _farseerWorld.Gravity; }
            set { _farseerWorld.Gravity = value; }
        }

        private FarseerPhysics.Dynamics.World _farseerWorld;

        public PhysicalWorld()
        {
            this._farseerWorld = new FarseerPhysics.Dynamics.World(Microsoft.Xna.Framework.Vector2.Zero);
        }

        public IBody CreateBody(GameObject gameObject)
        {
            return new Body(this._farseerWorld, gameObject);
        }

        internal void Update(GameTime gameTime)
        {
            // http://weblogs.asp.net/bsimser/farseer-tutorial-for-the-absolute-beginners
            _farseerWorld.Step(Math.Min((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f, (1f / 30f)));
        }
    }
}
