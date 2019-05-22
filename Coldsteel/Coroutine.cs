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

        private bool _finished;

        private YieldInstruction? _wait;

        internal Coroutine(IEnumerator routine)
        {
            _routine = routine;
        }

        public bool IsFinished => _finished;

        public void Stop()
        {
            _finished = true;
        }

        internal void Update(GameTime gameTime)
        {
            if (_finished)
                return;

            if (!_wait.HasValue)
            {
                _wait = _wait.Value.Increment(gameTime);
            }

            if (!_routine.MoveNext())
            {
                _finished = true;
                return;
            }

            _wait = _routine.Current is YieldInstruction yi ? yi : (YieldInstruction?)null;
        }
    }
}
