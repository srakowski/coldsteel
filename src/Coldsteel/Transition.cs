using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Transition
    {
        internal abstract void Start(Action whenDone);
        internal abstract void Update(IGameTime gameTime);
    }
}
