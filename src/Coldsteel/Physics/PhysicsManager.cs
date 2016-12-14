// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

namespace Coldsteel.Physics
{
    internal class PhysicsManager : GameComponent, IPhysicsManager
    {
        private ISceneManager _sceneManager;

        private List<RigidBody> _rigidBodies = new List<RigidBody>();

        private List<Collider> _colliders = new List<Collider>();

        public PhysicsManager(Game game) : base(game)
        {
            game.Services.AddService<IPhysicsManager>(this);
        }

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager = Game.Services.GetService<ISceneManager>();
        }

        public void RegisterRigidBody(RigidBody rigidBody) =>
            _rigidBodies.Add(rigidBody);

        public void RegisterCollider(Collider collider) =>
            _colliders.Add(collider);

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _rigidBodies.RemoveAll(rb => rb.GameObject.IsDestroyed);
            _colliders.RemoveAll(cl => cl.GameObject.IsDestroyed);

            foreach (var rigidBody in _rigidBodies)
            {
                var move = (rigidBody.Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds);

                var origPos = rigidBody.Transform.Position;
                rigidBody.GameObject.Transform.Position += move;

                var collider = _colliders.FirstOrDefault(c => c.GameObject == rigidBody.GameObject);
                if (collider == null)
                    continue;

                var collisions = CheckForCollision(collider as BoxCollider);
                if (collisions.Any())
                {
                    //TODO: inform collisions and figure physics out one day.
                }
            }
        }

        private IEnumerable<BoxCollider> CheckForCollision(BoxCollider collider)
        {
            return _colliders.OfType<BoxCollider>()
                .Where(c => c != collider && c.BoundingBox.Intersects(collider.BoundingBox));
        }
    }
}
