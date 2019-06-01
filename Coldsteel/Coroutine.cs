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

        private Wait _wait;

        internal Coroutine(IEnumerator routine)
        {
            _routine = routine;
        }

        public bool IsFinished { get; set; }

        internal void Update(GameTime gameTime)
        {
            if (IsFinished)
                return;

            if (!_wait.IsOver)
            {
                _wait = _wait.Update(gameTime);
                if (!_wait.IsOver)
                    return;
            }

            if (!_routine.MoveNext())
            {
                IsFinished = true;
                return;
            }

            _wait = _routine.Current is Wait w ? w : Wait.None();
        }
    }
}
