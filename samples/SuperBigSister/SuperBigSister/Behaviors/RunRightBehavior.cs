using Coldsteel;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.Behaviors
{
    public class RunRightBehavior : Behavior
    {
        public override void Initialize()
        {
            Animations.Play("run");
            Set.SpriteEffects(SpriteEffects.None);
        }
    }
}
