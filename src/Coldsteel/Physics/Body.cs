using System;
using System.Collections.Generic;
using System.Text;
using FarseerPhysics.Dynamics;
using FarseerPhysics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    internal class Body : IBody
    {
        private FarseerPhysics.Dynamics.World _farseerWorld;

        public Vector2 Position
        {
            get { return ConvertUnits.ToDisplayUnits(this._body.Position);  }
            set { this._body.Position = ConvertUnits.ToSimUnits(value); }
        }

        public float Rotation
        {
            get { return this._body.Rotation; }
            set { this._body.Rotation = value; }
        }

        public Vector2 Velocity
        {
            get { return this._body.LinearVelocity; }
            set { this._body.LinearVelocity = value; }
        }

        private bool _isRigid = false;

        public bool IsRigid
        {
            get { return _isRigid; }
            set
            {
                _isRigid = value;
                if (_isRigid)
                {
                    this._body.IgnoreGravity = false;
                    this._body.Mass = 1f;
                    this._body.IsSensor = false;
                }
                else
                {
                    this._body.IgnoreGravity = true;
                    this._body.Mass = 0f;
                    this._body.IsSensor = true;
                }
            }
        }

        private bool _enabled = false;

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                this._body.CollidesWith = _enabled ? Category.All : Category.None;
            }
        }

        private FarseerPhysics.Dynamics.Body _body;

        public Body(FarseerPhysics.Dynamics.World farseerWorld, GameObject gameObject)
        {
            this._farseerWorld = farseerWorld;
            this._body = new FarseerPhysics.Dynamics.Body(
                            this._farseerWorld,
                            Vector2.Zero,
                            0f,
                            BodyType.Dynamic,
                            gameObject
                            );

            this.IsRigid = false;
        }

        public void Dispose()
        {
            _farseerWorld.RemoveBody(this._body);
            this._body = null;
        }

        public void CreateBoxCollider(int width, int height)
        {
            var w = FarseerPhysics.ConvertUnits.ToSimUnits(width);
            var h = FarseerPhysics.ConvertUnits.ToSimUnits(height);
            FarseerPhysics.Common.Vertices rectangleVertices = FarseerPhysics.Common.PolygonTools.CreateRectangle(w / 2, h / 2);
            FarseerPhysics.Collision.Shapes.PolygonShape rectangleShape = new FarseerPhysics.Collision.Shapes.PolygonShape(rectangleVertices, 1.0f);
            var fixture = _body.CreateFixture(rectangleShape);
            fixture.IsSensor = true;
            fixture.OnCollision += HandleCollision;
        }

        private bool HandleCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            (fixtureA.Body.UserData as GameObject).HandlCollision(fixtureB.Body.UserData as GameObject);
            (fixtureB.Body.UserData as GameObject).HandlCollision(fixtureA.Body.UserData as GameObject);
            return true;
        }
    }
}
