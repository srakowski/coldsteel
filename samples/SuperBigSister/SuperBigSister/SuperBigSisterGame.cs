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
            Input.AddButtonControl("start")
                .Keyboard(Keys.Space);

            Input.AddButtonControl("jump")
                .Keyboard(Keys.Space);

            Input.AddButtonControl("left")
                .Keyboard(Keys.A, Keys.Left);

            Input.AddButtonControl("right")
                .Keyboard(Keys.D, Keys.Right);

            State.Start<MainMenuState>();
        }
    }
}
