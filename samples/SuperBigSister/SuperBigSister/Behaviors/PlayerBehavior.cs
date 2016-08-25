using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.Behaviors
{
    class PlayerBehavior : Behavior
    {
        public override void Initialize()
        {
            Animations.Play("stand");
        }
    }
}
