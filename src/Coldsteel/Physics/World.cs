// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Physics
{
    public class World : SceneElement
    {
        private bool _skipCollision = false;

        private List<Collider> _colliders = new List<Collider>();

        public string Name { get; set; }

        public Vector2 Gravity { get; set; } = Vector2.Zero;

        public World(string name)
        {
            this.Name = name;
        }

        internal void Step(GameTime gameTime, IEnumerable<PhysicsComponent> physicsComponents)
        {
            _skipCollision = !_skipCollision;

            //if (!_skipCollision)
                _colliders.Clear();

            foreach (var component in physicsComponents)
            {
                if (component is Body)
                    UpdateMotion(gameTime, component as Body);

                //if (!_skipCollision)
                    if (component is Collider)
                    {
                        var collider = component as Collider;
                        collider.Update();
                        _colliders.Add(collider);
                    }
            }

            //if (_skipCollision)
            //    return;

            Collide(gameTime, _colliders);
        }

        private enum Axis
        {
            None = 0,
            Horizontal,
            Vertical
        }

        private void UpdateMotion(GameTime gameTime, Body body)
        {
            body.AngularVelocity = ComputeVelocity(gameTime, Axis.None, body, body.AngularVelocity, body.AngularAcceleration, body.AngularDrag, body.MaxAngularVelocity);
            body.Rotation += MathHelper.ToRadians((body.AngularVelocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds));

            body.Velocity = new Vector2(ComputeVelocity(gameTime, Axis.Horizontal, body, body.Velocity.X, body.Acceleration.X, body.Drag.X, body.MaxVelocity.X),
                ComputeVelocity(gameTime, Axis.Vertical, body, body.Velocity.Y, body.Acceleration.Y, body.Drag.Y, body.MaxVelocity.Y));

            body.Position += (body.Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        private float ComputeVelocity(GameTime gameTime, Axis axis, Body body, float velocity, float acceleration, float drag, float max = 10000f)
        {
            var newVelocity = velocity;

            if (body.EnableGravity)
            {
                if (axis == Axis.Horizontal)
                {
                    newVelocity += (this.Gravity.X + body.Gravity.X) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else if (axis == Axis.Vertical)
                {
                    newVelocity += (this.Gravity.Y + body.Gravity.Y) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }

            if (acceleration != 0f)
            {
                newVelocity += (acceleration * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            else if (drag != 0f)
            {
                var effectiveDrag = drag * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

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

        private void Collide(GameTime gameTime, List<Collider> colliders)
        {
            // TODO: remember to add broad/narrow phase
            for (int i = 0; i < colliders.Count; i++)
            {
                for (int j = i + 1; j < colliders.Count; j++)
                {
                    var c1 = colliders[i];
                    var c2 = colliders[j];

                    var result = CheckCollision(c1, c2);
                    if (!result.CollidersIntersect)
                        continue;

                    c1.Transform.Position += result.MinTranslationVector;

                    var c1Vel = c1.Body.Velocity;
                    var c2Vel = c2.Body.Velocity;

                    c1.Body.Velocity = c2Vel;
                    c2.Body.Velocity = c1Vel;


                    ///c2.GameObject.Transform.Position += (result.MinSeparateVector / 2f);

                    //var c1Vel = c1.Body.Velocity;
                    //c1.Body.Velocity = c2.Body.Velocity;
                    //c2.Body.Velocity = c1Vel;

                    //var norm = c1.Body.Position - c2.Body.Position;

                    //var relVel = c2.Body.Velocity - c1.Body.Velocity;

                    //var velAlongNorm = Vector2.Dot(relVel, norm);

                    //if (velAlongNorm > 0f)
                    //    return;

                    //var e = Math.Min(c1.Body.Bounce, c2.Body.Bounce);
                    //var x = -(1f + e) * velAlongNorm;
                    //x /= 1f / c1.Body.Mass + 1 / c2.Body.Mass;

                    //var imp = x * norm;

                    //c1.Body.Velocity -= 1 / c1.Body.Mass * imp;
                    //c2.Body.Velocity += 1 / c2.Body.Mass * imp;



                }
            }
        }

        private struct CollisionResult
        {
            public bool CollidersIntersect;
            public Vector2 MinTranslationVector { get; set; }
        }

        private CollisionResult CheckCollision(Collider c1, Collider c2)
        {
            var result = new CollisionResult();
            result.CollidersIntersect = true;
            result.MinTranslationVector = Vector2.Zero;

            var minIntervalDistance = float.MaxValue;
            var minIntervalAxis = Vector2.Zero;

            var edges = c1.Edges.Concat(c2.Edges);
            foreach (var edge in edges)
            {
                // The line perpendicular to an edge is our axis.
                var axis = new Vector2(-edge.Y, edge.X);
                axis.Normalize();

                var i1 = Project(c1, axis);
                var i2 = Project(c2, axis);
                var iDistance = Interval.Distance(i1, i2);

                // If we find a gap between any of the verts then no collision has occured.
                if (iDistance > 0f)
                {
                    result.CollidersIntersect = false;
                    break;
                }

                if (Math.Abs(iDistance) < minIntervalDistance)
                {
                    minIntervalDistance = Math.Abs(iDistance); // TODO: does this need to be abs?
                    minIntervalAxis = axis;

                    var d = c1.Transform.Position - c2.Transform.Position;
                    if (Vector2.Dot(d, axis) < 0)
                        minIntervalAxis = -axis;
                }
            }

            if (result.CollidersIntersect)
                result.MinTranslationVector = minIntervalAxis * (minIntervalDistance + 1f);

            return result;
        }

        private Interval Project(Collider c, Vector2 axis)
        {
            var dp = Vector2.Dot(axis, c.Vertices[0]);
            var interval = new Interval(dp);
            for (var i = 1; i < c.Vertices.Length; i++)
            {
                dp = Vector2.Dot(axis, c.Vertices[i]);
                interval.Min = Math.Min(dp, interval.Min);
                interval.Max = Math.Max(dp, interval.Max);
            }
            return interval;
        }
    }
}
