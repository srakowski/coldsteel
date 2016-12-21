// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Coldsteel.Physics
{
    public class World : SceneElement
    {
        public string Name { get; set; }

        public Vector2 Gravity { get; set; } = Vector2.Zero;

        public World(string name)
        {
            this.Name = name;
        }

        internal void Step(GameTime gameTime, IEnumerable<Body> bodies)
        {
            foreach (var body in bodies)
                UpdateBody(gameTime, body);
        }

        private enum Axis
        {
            None = 0,
            Horizontal,
            Vertical
        }

        private void UpdateBody(GameTime gameTime, Body body)
        {
            body.AngularVelocity = ComputeVelocity(gameTime, Axis.None, body, body.AngularVelocity, body.AngularAcceleration, body.AngularDrag, body.MaxAngularVelocity);
            body.Rotation += MathHelper.ToRadians((body.AngularVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds));

            body.Velocity = new Vector2(ComputeVelocity(gameTime, Axis.Horizontal, body, body.Velocity.X, body.Acceleration.X, body.MaxVelocity.X),
                ComputeVelocity(gameTime, Axis.Vertical, body, body.Velocity.Y, body.Acceleration.Y, body.MaxVelocity.Y));

            body.Position += (body.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        private float ComputeVelocity(GameTime gameTime, Axis axis, Body body, float velocity, float acceleration, float drag, float max = 10000f)
        {
            var newVelocity = velocity;

            if (body.EnableGravity)
            {
                if (axis == Axis.Horizontal)
                {
                    newVelocity += (this.Gravity.X + body.Gravity.X) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (axis == Axis.Vertical)
                {
                    newVelocity += (this.Gravity.Y + body.Gravity.Y) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (acceleration != 0f)
            {
                newVelocity += (acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            else if (drag != 0f)
            {
                var effectiveDrag = drag * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (newVelocity - effectiveDrag > 0f)
                {
                    newVelocity -= effectiveDrag;
                }
                else if (newVelocity + effectiveDrag < 0f)
                {
                    newVelocity += effectiveDrag;
                }
                else
                {
                    newVelocity = 0f;
                }
            }

            if (newVelocity > max)
            {
                newVelocity = max;
            }
            else if (newVelocity < -max)
            {
                newVelocity = -max;
            }

            return newVelocity;
        }
    }
}
