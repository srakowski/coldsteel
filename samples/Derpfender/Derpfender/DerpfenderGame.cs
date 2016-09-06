using System;
using Coldsteel;
using Derpfender.States;
using Microsoft.Xna.Framework.Input;

namespace Derpfender
{
    public class DerpfenderGame : Game
    {
        public override void Initialize()
        {
            Input.AddButtonControl("MenuUp")
                .Keyboard(Keys.W, Keys.Up);
            Input.AddButtonControl("MenuDown")
                .Keyboard(Keys.S, Keys.Down);
            Input.AddButtonControl("MenuSelect")
                .Keyboard(Keys.Space, Keys.Enter);

            Input.AddButtonControl("MoveUp")
                .Keyboard(Keys.W, Keys.Up);
            Input.AddButtonControl("MoveDown")
                .Keyboard(Keys.S, Keys.Down);
            Input.AddButtonControl("Fire")
                .Keyboard(Keys.Space);

            State.Start<MainMenuState>();
        }
    }
}
