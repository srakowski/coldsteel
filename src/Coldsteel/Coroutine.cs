// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections;

namespace Coldsteel
{
    /// <summary>
    /// Encapsulates behavior logic whose execution is to be distributed
    /// over a series of frame updates.
    /// </summary>
    public class Coroutine
    {
        private IEnumerator _routine;

        private WaitYieldInstruction _wait;

        /// <summary>
        /// Has the Coroutine run to completion?
        /// </summary>
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
