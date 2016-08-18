using System;
using System.Collections.Generic;
using System.Text;
using FarseerPhysics.Dynamics;
using FarseerPhysics;

namespace Coldsteel.Physics
{
    internal class Body
    {
        private FarseerPhysics.Dynamics.World _farseerWorld;

        private GameObject _gameObject;

        private FarseerPhysics.Dynamics.Body _body;

        public Body(FarseerPhysics.Dynamics.World farseerWorld, GameObject gameObject)
        {
            this._farseerWorld = farseerWorld;
            this._gameObject = gameObject;
        }

        public void Initialize()
        {
            if (this._body != null)
                return;

            this._body = new FarseerPhysics.Dynamics.Body(
                this._farseerWorld,
                ConvertUnits.ToSimUnits(_gameObject.Transform.Position),
                _gameObject.Transform.Rotation,
                BodyType.Dynamic,
                _gameObject
                );
        }

        private bool HandleCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            (fixtureA.Body.UserData as GameObject).HandlCollision(fixtureB.Body.UserData as GameObject);
            (fixtureB.Body.UserData as GameObject).HandlCollision(fixtureA.Body.UserData as GameObject);
            return true;
        }

        public void Destroy()
        {
            this._farseerWorld.RemoveBody(_body);
            _body.Dispose();
            _body = null;
        }

        public void CreateBox(int width, int height)
        {
            var w = FarseerPhysics.ConvertUnits.ToSimUnits(width);
            var h = FarseerPhysics.ConvertUnits.ToSimUnits(height);
            FarseerPhysics.Common.Vertices rectangleVertices = FarseerPhysics.Common.PolygonTools.CreateRectangle(w / 2, h / 2);
            FarseerPhysics.Collision.Shapes.PolygonShape rectangleShape = new FarseerPhysics.Collision.Shapes.PolygonShape(rectangleVertices, 1.0f);
            var fixture = _body.CreateFixture(rectangleShape);
            fixture.IsSensor = true;
            fixture.OnCollision += HandleCollision;
        }

        public void SyncBodyToTransform()
        {
            if (_body == null)
                return;

            _gameObject.Transform.Position = FarseerPhysics.ConvertUnits.ToDisplayUnits(_body.Position);
            _gameObject.Transform.Rotation = _body.Rotation;
        }

        public void SyncTransformToBody()
        {
            if (_body == null)
                return;

            _body.Position = FarseerPhysics.ConvertUnits.ToSimUnits(_gameObject.Transform.Position);
            _body.Rotation = _gameObject.Transform.Rotation;
        }
    }
}
