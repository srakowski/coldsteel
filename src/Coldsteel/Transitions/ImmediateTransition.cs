using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Transitions
{
    public class ImmediateTransition : Transition
    {
        private Action _done;

        protected ImmediateTransition()
        {
        }

        internal override void Start(Action whenDone)
        {
            _done = whenDone;
        }

        internal override void Update(IGameTime gameTime)
        {
            _done.Invoke();
        }

        public static Transition In()
        {
            return new ImmediateTransition();
        }

        public static Transition Out()
        {
            return new ImmediateTransition();
        }
    }
}
