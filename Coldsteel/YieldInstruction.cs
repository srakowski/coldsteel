// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public struct YieldInstruction
    {
        private double _timeRemaining;

        public YieldInstruction(double millesecondsToWait)
        {
            _timeRemaining = millesecondsToWait;
        }

        public YieldInstruction? Increment(GameTime gameTime)
        {
            var timeRemaining = _timeRemaining - gameTime.ElapsedGameTime.TotalMilliseconds;
            return timeRemaining < 0.0
                ? new YieldInstruction(timeRemaining)
                : (YieldInstruction?)null;
        }
    }
}
