// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;

namespace Coldsteel
{
    public struct Wait
    {
        private IWaitStrategy _waitStrategy;

        private Wait(IWaitStrategy waitStrategy)
        {
            _waitStrategy = waitStrategy;
        }

        public bool IsOver => _waitStrategy == null || _waitStrategy.IsOver;

        public Wait Update(GameTime gameTime) => _waitStrategy.Update(gameTime);

        public static Wait None() => new Wait();

        public static Wait Duration(double milleseconds) => new Wait(new DurationStrategy(milleseconds));

        public static Wait Duration(TimeSpan timeSpan) => Duration(timeSpan.TotalMilliseconds);

        public static Wait Until(Func<bool> isOver) => new Wait(new UntilStrategy(isOver));

        public static Wait While(Func<bool> isActive) => new Wait(new WhileStrategy(isActive));

        private interface IWaitStrategy
        {
            bool IsOver { get; }
            Wait Update(GameTime gameTime);
        }

        private struct DurationStrategy : IWaitStrategy
        {
            private double _timeRemaining;

            public DurationStrategy(double timeRemainingInMS)
            {
                _timeRemaining = timeRemainingInMS;
            }

            public bool IsOver => _timeRemaining <= 0.0;

            public Wait Update(GameTime gameTime)
            {
                var timeRemaining = _timeRemaining - gameTime.ElapsedGameTime.TotalMilliseconds;
                return timeRemaining <= 0.0 ? None() : Duration(timeRemaining);
            }
        }

        private struct UntilStrategy : IWaitStrategy
        {
            private Func<bool> _isOver;

            public UntilStrategy(Func<bool> isOver)
            {
                _isOver = isOver;
            }

            public bool IsOver => _isOver.Invoke();

            public Wait Update(GameTime gameTime)
            {
                return IsOver ? None() : Until(_isOver);
            }
        }

        private struct WhileStrategy : IWaitStrategy
        {
            private Func<bool> _isActive;

            public WhileStrategy(Func<bool> isActive)
            {
                _isActive = isActive;
            }

            public bool IsOver => !_isActive.Invoke();

            public Wait Update(GameTime gameTime)
            {
                return IsOver ? None() : While(_isActive);
            }
        }
    }
}
