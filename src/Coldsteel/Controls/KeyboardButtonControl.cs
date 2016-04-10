using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public class KeyboardButtonControl : ButtonControl
    {
        public KeyboardButtonControl(string controlKey, Keys keyboardKey) : base(controlKey)
        {
        }

        public override bool IsDown
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
