using Coldsteel.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Input
{
    public class InputManager
    {
        private Dictionary<string, Control> _controls = new Dictionary<string, Control>();

        public ButtonControl AddButtonControl(string key)
        {
             var control = new ButtonControl();
            _controls[key] = control;
            return control;
        }
    }
}
