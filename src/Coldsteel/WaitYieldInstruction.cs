// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;

namespace Coldsteel
{
    /// <summary>
    /// A yield instruction that informs the coroutinte to wait a specified 
    /// period of time before proceeding with the next step.
    /// </summary>
    public class WaitYieldInstruction : YieldInstruction
    {
        private double _timeRemaining = 0;

        internal bool IsOver => _timeRemaining <= 0.0;

        private WaitYieldInstruction(float millesecondsToWait)
        {
            _timeRemaining = millesecondsToWait;
        }

        public void Update(GameTime gameTime) =>
            _timeRemaining -= gameTime.ElapsedGameTime.TotalMilliseconds;

        /// <summary>
        /// Creates a WaitYieldInstruction for the prescribed number of milleseconds.
        /// </summary>
        /// <param name="milleseconds"></param>
        /// <returns></returns>
        public static WaitYieldInstruction CreateWaitYieldInstruction(int milleseconds)
            => new WaitYieldInstruction((float)milleseconds);

        /// <summary>
        /// Creates a WaitYieldInstruction for the given Timespan.
        /// </summary>
        /// <param name="timespan"></param>
        /// <returns></returns>
        public static WaitYieldInstruction CreateWaitYieldInstruction(TimeSpan timespan)
            => new WaitYieldInstruction((float)timespan.TotalMilliseconds);
    }
}
