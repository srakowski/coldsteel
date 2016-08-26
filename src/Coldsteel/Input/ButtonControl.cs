using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Input
{
    public class ButtonControl : Control
    {
        private List<ButtonControl> _controls = new List<ButtonControl>();

        public ButtonControl Keyboard(Keys primary, Keys? alt = null)
        {
            _controls.Add(new KeyboardButtonControl(primary));
            if (alt.HasValue)
                _controls.Add(new KeyboardButtonControl(alt.Value));
            return this;
        }

        internal virtual bool ButtonIsDown() { return false; }

        public bool IsDown()
        {
            return _controls.Any(c => c.ButtonIsDown());
        }

        internal virtual bool ButtonIsUp() { return false; }

        public bool IsUp()
        {
            return !IsDown();
        }

        internal virtual bool ButtonWasDown() { return false; }

        public bool WasDown()
        {
            return _controls.Any(c => c.ButtonWasDown());
        }

        internal virtual bool ButtonWasUp() { return false; }

        public bool WasUp()
        {
            return _controls.Any(c => c.ButtonWasUp());
        }
    }
}
