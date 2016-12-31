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
        private List<Collider> _colliders = new List<Collider>();

        public string Name { get; set; }

        public Vector2 Gravity { get; set; } = Vector2.Zero;

        public World(string name)
        {
            this.Name = name;
        }

        internal void Step(GameTime gameTime, IEnumerable<PhysicsComponent> physicsComponents)
        {
            _colliders.Clear();

            foreach (var physicsComponent in physicsComponents)
            {
                physicsComponent.BeginPhysicsUpdate();

                if (physicsComponent is Body)
                    UpdateMotion(gameTime, physicsComponent as Body);

                if (physicsComponent is Collider)
                    _colliders.Add(physicsComponent as Collider);
            }

            Collide(gameTime, _colliders);

            foreach (var physicsComponent in physicsComponents)
                physicsComponent.EndPhysicsUpdate();
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

        private struct BroadRegion
        {
            public Polygon Shape;
            public List<Collider> IntersectingColliders;
        }

        private void Collide(GameTime gameTime, List<Collider> colliders)
        {
            if (!colliders.Any())
                return;

            var verts = colliders.SelectMany(c => c.Vertices);
            var firstVert = verts.First();
            Vector2 mins = firstVert;
            Vector2 maxs = firstVert;
            foreach (var vert in verts)
            {
                mins.X = Math.Min(vert.X, mins.X);
                mins.Y = Math.Min(vert.Y, mins.Y);
                maxs.X = Math.Max(vert.X, maxs.X);
                maxs.Y = Math.Max(vert.Y, maxs.Y);
            }

            var broadRegions = GetBroadColliders(mins, maxs, 2);

            foreach (var collider in colliders)
                foreach (var broadRegion in broadRegions)
                    if (broadRegion.Shape.Bounds.Intersects(collider.Shape.Bounds))
                        broadRegion.IntersectingColliders.Add(collider);

            // TODO: why not just do the collision detection as the colliders are 
            // added to the broad region? save another loop.
            foreach (var region in broadRegions)
                NarrowCollide(gameTime, region.IntersectingColliders);
        }

        private IEnumerable<BroadRegion> GetBroadColliders(Vector2 ul, Vector2 lr, int levels)
        {
            if (levels <= 0)
            {
                var ur = new Vector2(lr.X, ul.Y);
                var ll = new Vector2(ul.X, lr.Y);
                var pg = new Polygon()
                {
                    Vertices = new[]
                    {
                        ul,
                        ur,
                        lr,
                        ll
                    }
                };
                return new[] { new BroadRegion() {
                    Shape = pg,
                    IntersectingColliders = new List<Collider>()
                } };
            }

            var hw = (lr.X - ul.X) / 2f;
            var hh = (lr.Y - ul.Y) / 2f;

            var broadRegions = Enumerable.Empty<BroadRegion>();
            broadRegions = broadRegions.Concat(
                GetBroadColliders(new Vector2(ul.X, ul.Y), new Vector2(ul.X + hw, ul.Y + hh), levels - 1));
            broadRegions = broadRegions.Concat(
                GetBroadColliders(new Vector2(ul.X + hw, ul.Y), new Vector2(lr.X, ul.Y + hh), levels - 1));
            broadRegions = broadRegions.Concat(
                GetBroadColliders(new Vector2(ul.X, ul.Y + hh), new Vector2(ul.X + hw, lr.Y), levels - 1));
            broadRegions = broadRegions.Concat(
                GetBroadColliders(new Vector2(ul.X + hw, ul.Y + hh), new Vector2(lr.X, lr.Y), levels - 1));
            return broadRegions;
        }

        private void NarrowCollide(GameTime gameTime, List<Collider> colliders)
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                for (int j = i + 1; j < colliders.Count; j++)
                {
                    var c1 = colliders[i];
                    var c2 = colliders[j];

                    var result = CheckCollision(c1.Shape, c2.Shape);
                    if (!result.CollidersIntersect)
                        continue;

                    var collision = new Collision()
                    {
                        World = this,
                        Collider1 = c1,
                        Collider2 = c2
                    };
                    collision.GameObject1.DispatchMessage(collision);
                    collision.GameObject2.DispatchMessage(collision);

                    // No point in doing any more processing if one or both are
                    // destroyed post collision.
                    if (collision.GameObject1.IsDestroyed ||
                        collision.GameObject2.IsDestroyed)
                        continue;

                    var d = c1.Transform.Position - c2.Transform.Position;
                    if (Vector2.Dot(d, result.MinIntervalAxis) < 0)
                        result.MinIntervalAxis = -result.MinIntervalAxis;

                    c1.Transform.Position += result.MinIntervalAxis * (result.MinIntervalDistance + 1f);
                }
            }
        }

        private struct CollisionResult
        {
            public bool CollidersIntersect;
            public float MinIntervalDistance;
            public Vector2 MinIntervalAxis;
        }

        private CollisionResult CheckCollision(Polygon p1, Polygon p2)
        {
            var result = new CollisionResult();
            result.CollidersIntersect = true;

            var minIntervalDistance = float.MaxValue;
            var minIntervalAxis = Vector2.Zero;

            var edges = p1.Edges.Concat(p2.Edges);
            foreach (var edge in edges)
            {
                // The line perpendicular to an edge is our axis.
                var axis = new Vector2(-edge.Y, edge.X);
                axis.Normalize();

                var i1 = Project(p1, axis);
                var i2 = Project(p2, axis);
                var iDistance = Interval.Distance(i1, i2);

                // If we find a gap between any of the verts then no collision has occured.
                if (iDistance > 0f)
                {
                    result.CollidersIntersect = false;
                    break;
                }

                var absIntervalDistance = Math.Abs(iDistance);
                if (absIntervalDistance < minIntervalDistance)
                {
                    minIntervalDistance = absIntervalDistance;
                    minIntervalAxis = axis;
                }
            }

            if (result.CollidersIntersect)
            {
                result.MinIntervalDistance = minIntervalDistance;
                result.MinIntervalAxis = minIntervalAxis;
            }

            return result;
        }

        private Interval Project(Polygon p, Vector2 axis)
        {
            var dp = Vector2.Dot(axis, p.Vertices[0]);
            var interval = new Interval(dp);
            for (var i = 1; i < p.Vertices.Length; i++)
            {
                dp = Vector2.Dot(axis, p.Vertices[i]);
                interval.Min = Math.Min(dp, interval.Min);
                interval.Max = Math.Max(dp, interval.Max);
            }
            return interval;
        }
    }
}
