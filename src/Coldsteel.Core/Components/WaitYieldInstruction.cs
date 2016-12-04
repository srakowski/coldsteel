using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core.Components
{
    public class WaitYieldInstruction : YieldInstruction
    {
        private double _timeRemaining = 0;

        public bool IsOver => _timeRemaining <= 0.0;

        private WaitYieldInstruction(float millesecondsToWait)
        {
            _timeRemaining = millesecondsToWait;
        }

        public void Update(GameTime gameTime) =>
            _timeRemaining -= gameTime.ElapsedGameTime.TotalMilliseconds;

        public static WaitYieldInstruction CreateWaitYieldInstruction(TimeSpan timespan)
            => new WaitYieldInstruction((float)timespan.TotalMilliseconds);
    }
}
