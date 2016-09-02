using Coldsteel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.Behaviors
{
    public class IdleBehavior : Behavior
    {
        public override void Initialize()
        {
            Animations.Play("stand");
        }
    }
}
