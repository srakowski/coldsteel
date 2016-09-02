﻿using Coldsteel;
using SuperBigSister.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.Behaviors
{
    class StartGameBehavior : Behavior
    {
        public override void Update()
        {
            if (Input.GetButtonControl("start").IsDown())
                State.Start<GameplayState>();
        }
    }
}
