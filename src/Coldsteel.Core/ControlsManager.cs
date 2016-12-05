using Coldsteel.Core.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core
{
    public class ControlsManager
    {
        private Dictionary<string, Control> _gameControls = new Dictionary<string, Control>();

        internal ControlsManager()
        {
        }

        public void Add(string name, Control control)
        {
            _gameControls.Add(name, control);
        }

        public Control this[string controlName] =>
            _gameControls[controlName];

        public T Get<T>(string controlName) where T : Control =>
            this[controlName] as T;

        internal void Unload() =>
            _gameControls.Clear();
    }
}
