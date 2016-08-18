using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal class CoroutineWait
    {
        public bool IsOver { get { return _timeRemaining <= 0f; } }

        private float _timeRemaining = 0f;

        protected CoroutineWait(float millesecondsToWait)
        {
            _timeRemaining = millesecondsToWait;
        }

        internal void Update(IGameTime gameTime)
        {
            _timeRemaining -= gameTime.Delta;
        }

        internal static CoroutineWait WaitMilleseconds(int amount)
        {
            return new CoroutineWait(amount);
        }
    }
}
