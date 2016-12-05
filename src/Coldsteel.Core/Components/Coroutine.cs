using Microsoft.Xna.Framework;
using System.Collections;

namespace Coldsteel.Core.Components
{
    public class Coroutine
    {
        private IEnumerator _routine;

        private WaitYieldInstruction _wait;

        public bool IsComplete => !_routine.MoveNext();

        internal Coroutine(IEnumerator routine)
        {
            _routine = routine;
        }

        internal void Update(GameTime gameTime)
        {
            if (_wait != null)
            {
                _wait.Update(gameTime);
                if (!_wait.IsOver)
                    return;

                _wait = null;
            }

            if (IsComplete)
                return;

            _wait = _routine.Current as WaitYieldInstruction;
        }
    }
}
