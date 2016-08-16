using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Input;

namespace Coldsteel
{
    public class GameObjectComponent
    {
        public GameObject GameObject { get; internal set; }

        public InputManager Input => GameObject?.Input;

        public Transform Transform => GameObject?.Transform;

        public IGameTime GameTime => GameObject?.GameTime;
    }
}
