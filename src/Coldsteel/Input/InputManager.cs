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

        public ButtonControl GetButtonControl(string key) => this[key].ButtonControl;

        public Control this[string key]
        {
            get
            {
                if (!this._controls.ContainsKey(key))
                    throw new Exception($"\"{key}\" control not found. did you forget to add an input mapping?");

                return _controls[key];
            }
        }
    }
}
