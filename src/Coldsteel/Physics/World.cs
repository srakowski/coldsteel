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

        private GameTime _gameTime;

        public string Name { get; set; }

        public Vector2 Gravity { get; set; } = Vector2.Zero;

        public World(string name)
        {
            this.Name = name;
        }

        internal void Step(GameTime gameTime, IEnumerable<PhysicsComponent> physicsComponents)
        {
            _gameTime = gameTime;

            foreach (var body in physicsComponents.OfType<Body>())
                UpdateMotion(gameTime, body);

            _skipCollision = !_skipCollision;
            if (_skipCollision)
                return;

            var colliders = physicsComponents.OfType<Collider>().ToArray();
            Collide(gameTime, colliders);
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

        private void Collide(GameTime gameTime, Collider[] colliders)
        {
            for (var i = 0; i < colliders.Length; i++)
            {
                var c1 = colliders[i];
                for (var j = i + 1; j < colliders.Length; j++)
                {
                    var c2 = colliders[j];

                    if (!c1.Intersects(c2))
                        continue;

                    // We know at that point a collision has occurred
                    // TODO: tell behaviors about it.

                    // If one or the other or both are triggers then we don't
                    // need to do anything other than dispatch a collision event.
                    if (c1.IsTrigger || c2.IsTrigger)
                        continue;

                    // If both are static then there isn't any more to do, because
                    // collision detection from here on adjusts the position of the
                    // objects
                    if (c1.IsStatic && c2.IsStatic)
                        continue;

                    Separate(c1, c2);
                }
            }
        }

        private void Separate(Collider c1, Collider c2)
        {
            if (c1 is CircleCollider && c2 is CircleCollider)
            {
                SeparateCircle(c1, c2);
                return;
            }

            if (c1 is CircleCollider != c2 is CircleCollider)
            {
                var box = c1 as BoxCollider ?? c2 as BoxCollider;
                var circle = c1 as CircleCollider ?? c2 as CircleCollider;

                if ((circle.Position.Y < box.Top || circle.Position.Y > box.Bottom) &&
                    (circle.Position.X < box.Left || circle.Position.X > box.Right))
                {
                    SeparateCircle(c1, c2);
                    return;
                }
            }

            SeparateX(c1, c2);
            if (c1.Intersects(c2))
                SeparateY(c1, c2);
        }

        private void SeparateCircle(Collider c1, Collider c2)
        {
            var dx = c1.Position.X - c2.Position.X;
            var dy = c1.Position.Y - c2.Position.Y;

            var angleOfCollision = Math.Atan2(dy, dx);

            var overlap = 0f;

            if (c1 is CircleCollider != c2 is CircleCollider)
            {
                var boxCollider = c1 as BoxCollider ?? c2 as BoxCollider;
                var circleCollider = c1 as CircleCollider ?? c2 as CircleCollider;
                // overlap is relative to a corner of the box.
                if (circleCollider.Position.Y < boxCollider.Top)
                {
                    if (circleCollider.Position.X < boxCollider.Left)
                    {
                        overlap = Vector2.Distance(circleCollider.Position,
                            new Vector2(boxCollider.Left, boxCollider.Top));
                    }
                    else if (circleCollider.Position.X > boxCollider.Right)
                    {
                        overlap = Vector2.Distance(circleCollider.Position,
                            new Vector2(boxCollider.Right, boxCollider.Top));
                    }
                }
                else if (circleCollider.Position.Y > boxCollider.Bottom)
                {
                    if (circleCollider.Position.X < boxCollider.Left)
                    {
                        overlap = Vector2.Distance(circleCollider.Position,
                            new Vector2(boxCollider.Left, boxCollider.Bottom));
                    }
                    else if (circleCollider.Position.X > boxCollider.Right)
                    {
                        overlap = Vector2.Distance(circleCollider.Position,
                            new Vector2(boxCollider.Right, boxCollider.Bottom));
                    }
                }

                overlap *= -1;
            }
            else if (c1 is CircleCollider && c2 is CircleCollider)
            {
                var circleCollider1 = c1 as CircleCollider;
                var circleCollider2 = c2 as CircleCollider;
                overlap = (circleCollider1.Radius + circleCollider2.Radius) -
                    Vector2.Distance(circleCollider1.Position, circleCollider2.Position);
            }

            // Now for a bunch of crap I don't quite understand.

            var body1 = c1.Body;
            var body2 = c2.Body;

            var v1 = new Vector2(
                body1.Velocity.X * (float)Math.Cos(angleOfCollision) + body1.Velocity.Y * (float)Math.Sin(angleOfCollision),
                body1.Velocity.X * (float)Math.Sin(angleOfCollision) - body1.Velocity.Y * (float)Math.Cos(angleOfCollision));

            var v2 = new Vector2(
                body2.Velocity.X * (float)Math.Cos(angleOfCollision) + body2.Velocity.Y * (float)Math.Sin(angleOfCollision),
                body2.Velocity.X * (float)Math.Sin(angleOfCollision) - body2.Velocity.Y * (float)Math.Cos(angleOfCollision));

            var tempVel1 = ((body1.Mass - body2.Mass) * v1.X + 2 * body2.Mass * v2.X) / (body1.Mass + body2.Mass);
            var tempVel2 = (2 * body1.Mass * v1.X + (body2.Mass - body1.Mass) * v2.X) / (body1.Mass + body2.Mass);
            
            if (!c1.IsStatic)
            {
                body1.Velocity = new Vector2(
                    (tempVel1 * (float)Math.Cos(angleOfCollision) - v1.Y * (float)Math.Sin(angleOfCollision)) * body1.Bounce.X,
                    (v1.Y * (float)Math.Cos(angleOfCollision) + tempVel1 * (float)Math.Sin(angleOfCollision)) * body1.Bounce.Y);
            }

            if (!c2.IsStatic)
            {
                body2.Velocity = new Vector2(
                    (tempVel2 * (float)Math.Cos(angleOfCollision) - v2.Y * (float)Math.Sin(angleOfCollision)) * body2.Bounce.X,
                    (v2.Y * (float)Math.Cos(angleOfCollision) + tempVel2 * (float)Math.Sin(angleOfCollision)) * body2.Bounce.Y);
            }

            // TODO: fix problem when almost perpendicular maybe..?

            if (!c1.IsStatic)
            {
                body1.Position += new Vector2(
                    (body1.Velocity.X * (float)_gameTime.ElapsedGameTime.TotalMilliseconds) - overlap * (float)Math.Cos(angleOfCollision),
                    (body1.Velocity.Y * (float)_gameTime.ElapsedGameTime.TotalMilliseconds) - overlap * (float)Math.Sin(angleOfCollision));
            }

            if (!c2.IsStatic)
            {
                body1.Position += new Vector2(
                    (body2.Velocity.X * (float)_gameTime.ElapsedGameTime.TotalMilliseconds) + overlap * (float)Math.Cos(angleOfCollision),
                    (body2.Velocity.Y * (float)_gameTime.ElapsedGameTime.TotalMilliseconds) + overlap * (float)Math.Sin(angleOfCollision));
            }
        }

        private void SeparateX(Collider collider1, Collider collider2)
        {
            throw new NotImplementedException();
        }

        private void SeparateY(Collider collider1, Collider collider2)
        {
            throw new NotImplementedException();
        }

        //private bool Intersects(Collider c1, Collider c2)
        //{


        //    if (c1 is CircleCollider)
        //    {
        //        if (c2 is CircleCollider)
        //        {
        //            return Vector2.Distance(c1.Position, c2.Position) <=
        //                (c1 as CircleCollider).Radius + (c2 as CircleCollider).Radius;
        //        }
        //        else
        //        {
        //            return CircleBoxIntersects(c1 as CircleCollider, c2 as BoxCollider);
        //        }
        //    }
        //    else
        //    {
        //        if (c2 is CircleCollider)
        //        {
        //            return CircleBoxIntersects(c2 as CircleCollider, c1 as BoxCollider);
        //        }
        //        else
        //        {
        //            return c1.Intersec
        //        }

        //        return true;
        //    }
        //}

        //private bool CircleBoxIntersects(CircleCollider circleCollider, BoxCollider boxCollider)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
