using Coldsteel.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class InputManager
    {
        private Dictionary<string, Control> _controls = new Dictionary<string, Control>();

        public Control this[string controlName] =>
            _controls[controlName];

        public T GetControl<T>(string controlName) where T : Control =>
            this[controlName] as T;
    }
}
