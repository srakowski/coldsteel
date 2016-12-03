using Coldsteel.Core.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core
{
    internal class ControlsManager
    {
        private Dictionary<string, Control> _gameControls = new Dictionary<string, Control>();

        private Dictionary<string, Control> _sceneControls = new Dictionary<string, Control>();

        internal ControlsManager()
        {
        }

        public void Add(string name, Control control, Scope scope = Scope.Game)
        {
            if (scope == Scope.Game)
                _gameControls.Add(name, control);
            else
                _gameControls.Add(name, control);
        }

        public Control this[string controlName] =>
            _sceneControls.ContainsKey(controlName) 
                ? _sceneControls[controlName]
                : _gameControls[controlName];

        public T Get<T>(string controlName) where T : Control =>
            this[controlName] as T;

        internal void UnloadSceneControls() =>
            _sceneControls.Clear();

        internal void UnloadGameControls() =>
            _gameControls.Clear();

        internal void Unload()
        {
            UnloadSceneControls();
            UnloadGameControls();
        }
    }
}
