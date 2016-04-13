using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public struct Particle
    {
        public float TTL;
        public Vector2 Position;
        public Vector2 Accelaration;
        public Vector2 Velocity;
        public float Scale;
        public Color Color;
        public float ScaleVelocity;
    }
}
