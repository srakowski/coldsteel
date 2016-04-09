using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Behavior : GameObjectComponent
    {
        public virtual void HandleInput(IGameTime gameTime, Input input) { }
    }
}
