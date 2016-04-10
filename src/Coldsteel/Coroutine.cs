using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal class Coroutine
    {
        private bool _done = false;

        private IEnumerator _coroutine;

        private Action<Coroutine> _whenDone;

        private CoroutineWait _wait;

        public Coroutine(IEnumerator coroutine)
        {
            this._done = false;
            this._coroutine = coroutine;            
        }

        /// <summary>
        /// Do next iteration.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(IGameTime gameTime)
        {
            if (_done)
                return;

            if (_wait != null)
            {
                _wait.Update(gameTime);
                if (!_wait.IsOver)
                    return;

                _wait = null;
            }

            if (!_coroutine.MoveNext())
            {
                _done = true;
                _whenDone?.Invoke(this);
                return;
            }

            _wait = _coroutine.Current as CoroutineWait;
        }

        /// <summary>
        /// Registers a callback to be executed when the routine finally exits.
        /// </summary>
        /// <param name="doThis"></param>
        /// <returns></returns>
        internal Coroutine WhenDone(Action<Coroutine> doThis)
        {
            _whenDone = doThis;
            return this;
        }
    }
}
