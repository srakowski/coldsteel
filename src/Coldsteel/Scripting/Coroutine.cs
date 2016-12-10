// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections;

namespace Coldsteel.Scripting
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
        public bool IsComplete { get; private set; } = false;

        internal Coroutine(IEnumerator routine)
        {
            _routine = routine;
        }

        internal void Update(GameTime gameTime)
        {
            if (IsComplete)
                return;

            if (_wait != null)
            {
                _wait.Update(gameTime);
                if (!_wait.IsOver)
                    return;

                _wait = null;
            }

            if (!_routine.MoveNext())
            {
                IsComplete = true;
            }

            _wait = _routine.Current as WaitYieldInstruction;
        }
    }
}
