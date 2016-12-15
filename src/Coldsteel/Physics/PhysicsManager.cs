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

        public PhysicsManager(Game game) : base(game)
        {
            game.Services.AddService<IPhysicsManager>(this);
        }

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager = Game.Services.GetService<ISceneManager>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
