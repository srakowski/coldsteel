﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    internal struct GameTimeWrapper : IGameTime
    {
        private GameTime _gameTime;

        public float Delta
        {
            get
            {
                return (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public GameTimeWrapper(GameTime gameTime)
        {
            _gameTime = gameTime;
        }
    }
}
