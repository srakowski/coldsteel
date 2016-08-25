using Coldsteel;
using Microsoft.Xna.Framework.Input;
using SuperBigSister.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister
{
    class SuperBigSisterGame : Game
    {
        public override void Initialize()
        {
            Input.AddButtonControl("Start")
                .Keyboard(Keys.Space);

            State.Start<MainMenuState>();
        }
    }
}
