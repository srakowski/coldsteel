// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel.Physics
{
    internal class CollisionManager : GameComponent
    {
        private ISceneManager _sceneManager;

        public CollisionManager(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager = Game.Services.GetService<ISceneManager>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var boxColliders = _sceneManager?.ActiveScene?.GameObjects
                .SelectMany(go => go.Components).OfType<BoxCollider>()
                .ToArray() ?? new BoxCollider[] { };

            for (int i = 0; i < boxColliders.Count(); i++)
                for (int j = i + 1; j < boxColliders.Count(); j++)
                {
                    var box1 = boxColliders[i];
                    var box2 = boxColliders[j];
                    if (box1.BoundingBox.Intersects(box2.BoundingBox))
                    {
                        // we have a collision, do something
                    }
                }
        }
    }
}
